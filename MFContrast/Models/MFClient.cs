using System;
namespace MFContrast.Models
{
    // To Be Implemented in each 'FundType' Branch of MutualFundTree

    // MutualFundTree will be a composite structure containing 3 main 
    // branches : Equity, Bond and Balanced

    // Each branch will have a list of mutual funds of their corresponding types

    // MutualFundTree will be a global singleton object created when the app begins

    // This will allow to access all funds and their holdings in an organized way
    // while also allowing for changes and additions to subclasses later

    public enum FactoryEnum
    {
        Equity,
        Bond,
        Balanced
    }


    // Three Branches of MutualFundTree will 
    public class MFClient
    {
        public MFClient(FundFactory factory, string Ticker)
        {
            MutualFund = factory.CreateFund(Ticker);
            GetHoldings = factory.CreateHoldings();
        }

        public MF MutualFund { get; }
        public Holdings GetHoldings { get; }
    }

    public abstract class FundFactory
    {
        public abstract MF CreateFund(string Ticker);
        public abstract Holdings CreateHoldings();
    }

    public class EquityFundFactory : FundFactory
    {
        public override MF CreateFund(string Ticker)
        {
            return new EquityMF();
        }

        public override Holdings CreateHoldings()
        {
            return new EquityHoldings();
        }
    }

    public class BondFundFactory : FundFactory
    {
        public override MF CreateFund(string Ticker)
        {
            return new BondMF();
        }

        public override Holdings CreateHoldings()
        {
            return new BondHoldings();
        }
    }

    public class BalancedFundFactory : FundFactory
    {
        public override MF CreateFund(string Ticker)
        {
            return new BalancedMF();
        }

        public override Holdings CreateHoldings()
        {
            return new BalancedHoldings();
        }
    }

    public abstract class MF { }
    public class EquityMF : MF { }
    public class BondMF : MF { }
    public class BalancedMF : MF { }
    public abstract class Holdings { }
    public class EquityHoldings: Holdings { }
    public class BondHoldings: Holdings { }
    public class BalancedHoldings: Holdings { }
}
