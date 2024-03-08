using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BlocksCandyController
{
    private BlocksCandyView _blocksCandyView;
    private int _currentIndexCandyLine;

    public BlocksCandyController(BlocksCandyView blocksCandyView)
    {
        _blocksCandyView = blocksCandyView;
        _currentIndexCandyLine = 0;
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
            ShowCandyLine(i);

        _currentIndexCandyLine += _blocksCandyView.Increment;

        await Task.Delay(TimeSpan.FromSeconds(_blocksCandyView.IncrementPerSecond));
        BaseUpdate();
    }

    private void ShowCandyLineStart()
    {
        for (int i = 0; i < _blocksCandyView.CountStart; i++)
        {
            ShowCandyLine(i);
            _currentIndexCandyLine = i;
        }
    }

    private void ShowCandyLine(int indexCandyLine)
    {
        foreach (var blockCandyLine in _blocksCandyView.ListCandyLine)
        {
            foreach (var candy in blockCandyLine.CandyLines[indexCandyLine].Candies)
                candy.SetImage(_blocksCandyView.GetRandomCandyImage());

            blockCandyLine.CandyLines[indexCandyLine].SetActiveCandyLine(true);
        }
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
