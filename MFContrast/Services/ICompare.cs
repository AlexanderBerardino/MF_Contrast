using System.Collections.Generic;
using MFContrast.Models;

namespace MFContrast.Services
{
    public interface ICompare
    {
        List<Holding> S1Complement { get; }
        List<Holding> S2Complement { get; }
        List<string> S1UnionS2 { get; }
        double F2InF1 { get; }
        double F1InF2 { get; }
        double OverlapPercentage { get; }
        double F1TopTen { get; }
        double F2TopTen { get; }
    }
}
