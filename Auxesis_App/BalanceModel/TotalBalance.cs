using System;
using System.Collections.Generic;
using System.Text;

namespace Auxesis_App.BalanceModel
{
    public class TotalBalance
    {
        public string title { get; set; }
        public string value { get; set; }
        public string type { get; set; }
    }
    public class Deposited
    {
        public string title { get; set; }
        public string value { get; set; }
        public string type { get; set; }

    }

    public class Withdrawn
    {
        public string title { get; set; }
        public string value { get; set; }
        public string type { get; set; }

    }

    public class Invested
    {
        public string title { get; set; }
        public string value { get; set; }
        public string type { get; set; }

    }

    public class Pending
    {
        public string title { get; set; }
        public string value { get; set; }
        public string type { get; set; }

    }

    public class Fees
    {
        public string title { get; set; }
        public string value { get; set; }
        public string type { get; set; }

    }

    public class Repaid
    {
        public string title { get; set; }
        public string value { get; set; }
        public string type { get; set; }

    }

    public class InterestPaid
    {
        public string title { get; set; }
        public string value { get; set; }
        public string type { get; set; }

    }

    public class Reserved
    {
        public string title { get; set; }
        public string value { get; set; }
        public string type { get; set; }

    }

    public class WrittenOff
    {
        public string title { get; set; }
        public string value { get; set; }
        public string type { get; set; }

    }

    public class MpgPurchase
    {
        public string title { get; set; }
        public string value { get; set; }
        public string type { get; set; }

    }

    public class MpgsPurchase
    {
        public string title { get; set; }
        public string value { get; set; }
        public string type { get; set; }

    }

    public class Data
    {
        public TotalBalance total_balance { get; set; }
        public Deposited deposited { get; set; }
        public Withdrawn withdrawn { get; set; }
        public Invested invested { get; set; }
        public Pending pending { get; set; }
        public Fees fees { get; set; }
        public Repaid repaid { get; set; }
        public InterestPaid interest_paid { get; set; }
        public Reserved reserved { get; set; }
        public WrittenOff written_off { get; set; }
        public MpgPurchase mpg_purchase { get; set; }
        public MpgsPurchase mpgs_purchase { get; set; }

    }

    public class Balance
    {
        public string heading { get; set; }
        public Data data { get; set; }

    }

    public class Portfolio2
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class NoArrear
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class Arrears4589Days
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class Arrears90179Days
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class Arrears190364Days
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class Arrears365Days
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class TotalReceivable
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class Reserved2
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class PortfolioValue
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class Data2
    {
        public Portfolio2 portfolio { get; set; }
        public NoArrear no_arrear { get; set; }
        public Arrears4589Days arrears_45_89_days { get; set; }
        public Arrears90179Days arrears_90_179_days { get; set; }
        public Arrears190364Days arrears_190_364_days { get; set; }
        public Arrears365Days arrears_365_days { get; set; }
        public TotalReceivable total_receivable { get; set; }
        public Reserved2 reserved { get; set; }
        public PortfolioValue portfolio_value { get; set; }

    }

    public class Portfolio
    {
        public string heading { get; set; }
        public Data2 data { get; set; }

    }

    public class NetReturn2
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class AverageReturn
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class IncidentalPayments
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class Fees2
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class Reserved3
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class WrittenOff2
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class LastNetReturn
    {
        public string title { get; set; }
        public string value { get; set; }

    }

    public class Data3
    {
        public NetReturn2 net_return { get; set; }
        public AverageReturn average_return { get; set; }
        public IncidentalPayments incidental_payments { get; set; }
        public Fees2 fees { get; set; }
        public Reserved3 reserved { get; set; }
        public WrittenOff2 written_off { get; set; }
        public LastNetReturn last_net_return { get; set; }

    }

    public class NetReturn
    {
        public string heading { get; set; }
        public Data3 data { get; set; }

    }

    public class Root
    {
        public int user_login_status { get; set; }
        public Balance balance { get; set; }
        public Portfolio portfolio { get; set; }
        public NetReturn net_return { get; set; }

    }
}
