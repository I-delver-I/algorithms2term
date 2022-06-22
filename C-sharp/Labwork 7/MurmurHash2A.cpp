#define mmix(h,k) { k *= m; k ^= k >> r; k *= m; h *= m; h ^= k; }

unsigned int MurmurHash2A ( const void * key, int len, unsigned int seed )
{
	const unsigned int m = 0x5bd1e995;
	const int r = 24;
	unsigned int l = len;

	const unsigned char * data = (const unsigned char *)key;

	unsigned int h = seed;

	while(len >= 4)
	{
		unsigned int k = *(unsigned int*)data;

		mmix(h,k);

		data += 4;
		len -= 4;
	}

	unsigned int t = 0;

	switch(len)
	{
	case 3: t ^= data[2] << 16;
	case 2: t ^= data[1] << 8;
	case 1: t ^= data[0];
	};

	mmix(h,t);
	mmix(h,l);

	h ^= h >> 13;
	h *= m;
	h ^= h >> 15;

	return h;
}

class CMurmurHash2A
{
public:

	void Begin ( unsigned int seed = 0 )
	{
		m_hash  = seed;
		m_tail  = 0;
		m_count = 0;
		m_size  = 0;
	}

	void Add ( const unsigned char * data, int len )
	{
		m_size += len;

		MixTail(data,len);

		while(len >= 4)
		{
			unsigned int k = *(unsigned int*)data;

			mmix(m_hash,k);

			data += 4;
			len -= 4;
		}

		MixTail(data,len);
	}

	unsigned int End ( void )
	{
		mmix(m_hash,m_tail);
		mmix(m_hash,m_size);

		m_hash ^= m_hash >> 13;
		m_hash *= m;
		m_hash ^= m_hash >> 15;

		return m_hash;
	}

private:

	static const unsigned int m = 0x5bd1e995;
	static const int r = 24;

	void MixTail ( const unsigned char * & data, int & len )
	{
		while( len && ((len<4) || m_count) )
		{
			m_tail |= (*data++) << (m_count * 8);

			m_count++;
			len--;

			if(m_count == 4)
			{
				mmix(m_hash,m_tail);
				m_tail = 0;
				m_count = 0;
			}
		}
	}

	unsigned int m_hash;
	unsigned int m_tail;
	unsigned int m_count;
	unsigned int m_size;
};
