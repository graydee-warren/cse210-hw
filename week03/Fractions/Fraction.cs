using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    public int GetNumerator()
    {
        return _top;
    }

    public void SetNumerator(int top)
    {
        _top = top;
    }
    
    public int GetDenominator()
    {
        return _bottom;
    }

    public void SetDenominator(int bottom)
    {
        _bottom = bottom;
    }

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNum)
    {
        _top = wholeNum;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }
    
    public string GetFractionString()
    {
        string fractionString = $"{_top}/{_bottom}";
        return fractionString; 
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
    
    
}

