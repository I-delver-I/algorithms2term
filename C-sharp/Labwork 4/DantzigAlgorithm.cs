namespace Labwork_4
{
    public class DantzigAlgorithm
    {
        void Danzig(int Adj = new int[][6], ref int n)
        {
            int d0 = new int[6][6];
            for(int i = 0; i < n; i++)
                for(int j = 0; j < n; j++)
                    d0[i][j] = Adj[i][j];
            int minval;
            int minx;
            
        
            for(int m = 0; m < n; m++)
            {
                //lines
                minval = max;
                for(int i = 0; i < m-1; i++)
                {
                    for(int j = 0; j < m-1; j++)
                        if(i != j)
                            if(minval > d0[m][i]+Adj[i][j])
                            {
                                minval = d0[m][i]+Adj[i][j];
                                Adj[m][j] = minval;
                            }
                }
                //rows
                minval = max;
                for(int j = 0; j < m-1; j++)
                {
                    for(int i = 0; i < m-1; i++)
                        if(j != i)
                        if(minval > Adj[i][j] + d0[j][m])
                        {
                            minval = Adj[i][j] + d0[j][m];
                            Adj[i][m] = minval;
                        }
                }
                
                for(int i = 0; i < m-1; i++)
                {
                    for(int j = 0; j < m-1; j++)
                    {
                        if(i != j)
                            Adj[i][j]=min(Adj[i][m]+Adj[m][j],Adj[i][j]);
                    }
                }
            } // m
            //output
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    cout<<setw(5)<<Adj[i][j]<<" ";
                }
                cout<<endl;
            }
        }//end
        void Warshall(int Adj = new int[][6], ref int n)
        {
            for (int k=0; k<n; k++)
                for (int i=0; i<n; i++)
                    for (int j=0; j<n; j++)
                        Adj[i][j]=min(Adj[i][j],Adj[i][k] + Adj[k][j]);
            
            for (int i=0; i<n; i++)
            {
                for (int j=0; j<n; j++) 
                    cout<<setw(3)<<Adj[i][j]<<setw(3);
                cout<<endl;
            }
        }
    }
}