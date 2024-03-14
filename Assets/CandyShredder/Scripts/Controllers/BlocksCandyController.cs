using System;
using System.Threading;
using System.Threading.Tasks;

public class BlocksCandyController
{
    private BlocksCandyView _blocksCandyView;
    private int _currentIndexCandyLine;
    private CancellationTokenSource _tokenSource;

    public BlocksCandyController(BlocksCandyView blocksCandyView)
    {
        _blocksCandyView = blocksCandyView;
        _currentIndexCandyLine = 0;
        _tokenSource = new CancellationTokenSource();
    }

    public void Initialize()
    {
        InvisibleCandyLine();
        SortCandyLine();
        ShowCandyLineStart();
        BaseUpdate();
    }

    public void BaseUpdate()
    {
        UpdateCandyLine();
    }

    public async void UpdateCandyLine()
    {
        for (int i = _currentIndexCandyLine; i < _currentIndexCandyLine + _blocksCandyView.Increment; i++)
        {
            var isShowedCandyLine = TryShowCandyLine(i);

            if (isShowedCandyLine == false)
                return;
        }

        _currentIndexCandyLine += _blocksCandyView.Increment;

        await Task.Delay(_blocksCandyView.IncrementPerSecond != -1 ? (int)(_blocksCandyView.IncrementPerSecond * 1000) : -1, _tokenSource.Token);
        BaseUpdate();
    }

    public void OnResumeGame()
    {
        _tokenSource.Cancel();
        _tokenSource = new CancellationTokenSource();
    }

    private void ShowCandyLineStart()
    {
        for (int i = 0; i < _blocksCandyView.CountStart; i++)
        {
            if(TryShowCandyLine(i))
                _currentIndexCandyLine = i;
        }
    }

    private bool TryShowCandyLine(int indexCandyLine)
    {
        foreach (var blockCandyLine in _blocksCandyView.ListCandyLine)
        {
            if (indexCandyLine >= blockCandyLine.CandyLines.Count)
                return false;

            foreach (var candy in blockCandyLine.CandyLines[indexCandyLine].Candies)
                candy.SetImage(_blocksCandyView.GetRandomCandyImage());

            blockCandyLine.CandyLines[indexCandyLine].SetActiveCandyLine(true);
        }

        return true;
    }

    private void SortCandyLine()
    {
        foreach (var blockCandyLine in _blocksCandyView.ListCandyLine)
        {
            if (blockCandyLine.CandyLines.Count == 0)
                return;

            blockCandyLine.CandyLines.Sort(
                (CandyLineView candyLine1, CandyLineView candyLine2) =>
                {
                    return candyLine1.NumberLine.CompareTo(candyLine2.NumberLine);
                });
        }
    }

    private void InvisibleCandyLine()
    {
        foreach (var blockCandyLine in _blocksCandyView.ListCandyLine)
        {
            for (int i = 0; i < blockCandyLine.CandyLines.Count; i++)
                blockCandyLine.CandyLines[i].SetActiveCandyLine(false);
        }
    }
}
