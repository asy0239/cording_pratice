var robotService = new TomatoCheckService();
robotService.Execute();

class TomatoCheckService
{
    private int[] dx = { 1, -1, 0, 0, 0, 0 };
    private int[] dy = { 0, 0, 1, -1, 0, 0 };
    private int[] dz = { 0, 0, 0, 0, 1, -1 };

    public void Execute()
    {
        var (M, N, H) = CreateTomatoBoxInfo();
        var tomatoBox = CreateTomatoBox(M, N, H);
        InitializeTomatoBox(tomatoBox, M, N, H);
        int result = GetMinimumDaysToRipeAllTomatoes(tomatoBox, M, N, H);
        Console.WriteLine(result);
    }

    private void InitializeTomatoBox(Tomato[,,] tomatoBox, int M, int N, int H)
    {
        for (int h = 0; h < H; h++)
        {
            for (int n = 0; n < N; n++)
            {
                var line = Console.ReadLine()!.Split();
                for (int m = 0; m < M; m++)
                {
                    tomatoBox[m, n, h] = new Tomato((TomatoState)int.Parse(line[m]));
                }
            }
        }
    }

    private (int M, int N, int H) CreateTomatoBoxInfo()
    {
        var TomatoBoxInfo = Console.ReadLine()!.Split();
        var BoxM = int.Parse(TomatoBoxInfo[0]);
        var BoxN = int.Parse(TomatoBoxInfo[1]);
        var BoxH = int.Parse(TomatoBoxInfo[2]);

        return (BoxM, BoxN, BoxH);
    }

    private Tomato[,,] CreateTomatoBox(int boxM, int boxN, int boxH)
    {
        return new Tomato[boxM, boxN, boxH];
    }

    private int GetMinimumDaysToRipeAllTomatoes(Tomato[,,] tomatoBox, int M, int N, int H)
    {
        Queue<(int x, int y, int z)> queue = new Queue<(int x, int y, int z)>();
        int unripeCount = 0;

        for (int h = 0; h < H; h++)
        {
            for (int n = 0; n < N; n++)
            {
                for (int m = 0; m < M; m++)
                {
                    if (tomatoBox[m, n, h].State == TomatoState.Ripe)
                    {
                        queue.Enqueue((m, n, h));
                    }
                    else if (tomatoBox[m, n, h].State == TomatoState.Unripe)
                    {
                        unripeCount++;
                    }
                }
            }
        }

        if (unripeCount == 0) return 0;

        int days = -1;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            days++;
            for (int i = 0; i < size; i++)
            {
                var (x, y, z) = queue.Dequeue();
                for (int d = 0; d < 6; d++)
                {
                    int nx = x + dx[d];
                    int ny = y + dy[d];
                    int nz = z + dz[d];

                    if (nx >= 0 && ny >= 0 && nz >= 0 && nx < M && ny < N && nz < H && tomatoBox[nx, ny, nz].State == TomatoState.Unripe)
                    {
                        tomatoBox[nx, ny, nz].State = TomatoState.Ripe;
                        queue.Enqueue((nx, ny, nz));
                        unripeCount--;
                    }
                }
            }
        }

        return unripeCount == 0 ? days : -1;
    }
}

enum TomatoState
{
    Ripe = 1,
    Unripe = 0,
    None = -1
}

class Tomato
{
    public TomatoState State { get; set; }

    public Tomato(TomatoState state)
    {
        State = state;
    }
}