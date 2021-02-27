#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBApi;

#endregion

namespace AutoTrading  {

    public class IBTrader : EWrapper {

        #region Fields

        private EClientSocket ecs;
        private int nextOrderId;

        #endregion

        #region Constructor

        public IBTrader() {
            ecs = new EClientSocket(this);
        }

        #endregion

        #region Properties

        public EClientSocket ClientSocket {
            get { return ecs; }
            set { ecs = value; }
        }

        public int NextOrderId {
            get { return nextOrderId; }
        }

        #endregion

        #region EWrapper Implementation

        #region Connection & Server

        void EWrapper.currentTime(long time) {
            Console.WriteLine("Current time: " + time + "\n");
        }
        
        void EWrapper.connectionClosed() {
            throw new NotImplementedException();
        }

        void EWrapper.error(Exception e) {
            Console.WriteLine(e.StackTrace);
        }

        void EWrapper.error(string str) {
            Console.WriteLine(str);
        }

        void EWrapper.error(int id, int errorCode, string errorMsg) {
            Console.WriteLine("Error.Id: " + id + ", Code: " + errorCode + ", Msg: " + errorMsg + "\n");
        }
        
        #endregion

        #region Market Data Methods

        void EWrapper.tickPrice(int tickerId, int field, double price, int canAutoExecute) {
            Console.WriteLine("Tick Price. Tcker Id: " + tickerId + ", Field: " + field + ", Price: " + price + ", CanAutoExecute: " + canAutoExecute + "\n");
        }

        void EWrapper.tickSize(int tickerId, int field, int size) {
            Console.WriteLine("Tic Size. Tcker Id: " + tickerId + ", Field: " + field + ", Size: " + size + "\n");
        }

        void EWrapper.tickString(int tickerId, int field, string value) {
            throw new NotImplementedException();
        }

        void EWrapper.tickGeneric(int tickerId, int field, double value) {
            throw new NotImplementedException();
        }

        void EWrapper.tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureExpiry, double dividendImpact, double dividendsToExpiry) {
            throw new NotImplementedException();
        }

        void EWrapper.tickSnapshotEnd(int tickerId) {
            throw new NotImplementedException();
        }

        void EWrapper.marketDataType(int reqId, int marketDataType) {
            throw new NotImplementedException();
        }

        void EWrapper.tickOptionComputation(int tickerId, int field, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice) {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Orders

        void EWrapper.nextValidId(int orderId) {
            Console.WriteLine("Next Valid Id: " + orderId + "\n");
            nextOrderId = orderId;
        }

        void EWrapper.deltaNeutralValidation(int reqId, UnderComp underComp) {
            throw new NotImplementedException();
        }

        void EWrapper.orderStatus(int orderId, string status, int filled, int remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld) {
            throw new NotImplementedException();
        }

        void EWrapper.openOrder(int orderId, Contract contract, Order order, OrderState orderState) {
            throw new NotImplementedException();
        }

        void EWrapper.openOrderEnd() {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Account & Portfolio

        void EWrapper.accountSummary(int reqId, string account, string tag, string value, string currency) {
            throw new NotImplementedException();
        }

        void EWrapper.accountSummaryEnd(int reqId) {
            throw new NotImplementedException();
        }

        void EWrapper.updateAccountValue(string key, string value, string currency, string accountName) {
            throw new NotImplementedException();
        }

        void EWrapper.updatePortfolio(Contract contract, int position, double marketPrice, double marketValue, double averageCost, double unrealisedPNL, double realisedPNL, string accountName) {
            throw new NotImplementedException();
        }

        void EWrapper.updateAccountTime(string timestamp) {
            throw new NotImplementedException();
        }

        void EWrapper.accountDownloadEnd(string account) {
            throw new NotImplementedException();
        }

        void EWrapper.position(string account, Contract contract, int pos, double avgCost) {
            throw new NotImplementedException();
        }

        void EWrapper.positionEnd() {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Contract Details

        void EWrapper.bondContractDetails(int reqId, ContractDetails contract) {
            throw new NotImplementedException();
        }

        void EWrapper.contractDetails(int reqId, ContractDetails contractDetails) {
            throw new NotImplementedException();
        }

        void EWrapper.contractDetailsEnd(int reqId) {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Execution

        void EWrapper.execDetails(int reqId, Contract contract, Execution execution) {
            throw new NotImplementedException();
        }

        void EWrapper.execDetailsEnd(int reqId) {
            throw new NotImplementedException();
        }

        void EWrapper.commissionReport(CommissionReport commissionReport) {
            throw new NotImplementedException();
        }

        #endregion

        #region Market Depth

        void EWrapper.updateMktDepth(int tickerId, int position, int operation, int side, double price, int size) {
            throw new NotImplementedException();
        }

        void EWrapper.updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, int size) {
            throw new NotImplementedException();
        }

        #endregion

        #region News Bulletins
        
        void EWrapper.updateNewsBulletin(int msgId, int msgType, string message, string origExchange) {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Financial Advisors

        void EWrapper.managedAccounts(string accountsList) {
            Console.WriteLine("Account list: " + accountsList + "\n");
        }
        
        void EWrapper.receiveFA(int faDataType, string faXmlData) {
            throw new NotImplementedException();
        }

        #endregion

        #region Historical Data

        void EWrapper.historicalData(int reqId, string date, double open, double high, double low, double close, int volume, int count, double WAP, bool hasGaps) {
            throw new NotImplementedException();
        }

        void EWrapper.historicalDataEnd(int reqId, string start, string end) {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Market Scanners

        void EWrapper.scannerParameters(string xml) {
            throw new NotImplementedException();
        }

        void EWrapper.scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr) {
            throw new NotImplementedException();
        }

        void EWrapper.scannerDataEnd(int reqId) {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Real Time bars
        
        void EWrapper.realtimeBar(int reqId, long time, double open, double high, double low, double close, long volume, double WAP, int count) {
            throw new NotImplementedException();
        }
        
        #endregion

        #region Fundamental Data

        void EWrapper.fundamentalData(int reqId, string data) {
            throw new NotImplementedException();
        }

        #endregion

        #region Display Groups

        void EWrapper.displayGroupList(int reqId, string groups) {
            throw new NotImplementedException();
        }

        void EWrapper.displayGroupUpdated(int reqId, string contractInfo) {
            throw new NotImplementedException();
        }

        #endregion

        #region Verify methods

        void EWrapper.verifyMessageAPI(string apiData) {
            throw new NotImplementedException();
        }

        void EWrapper.verifyCompleted(bool isSuccessful, string errorText) {
            throw new NotImplementedException();
        }
 
        #endregion

        #endregion
    }
}
