using System;

namespace NKart.Examine.DataServices
{
    public interface ILogService
    {
        string ProviderName { get; set; }
        void AddErrorLog(int nodeId, string msg, Exception ex);
        void AddInfoLog(int nodeId, string msg);
        void AddVerboseLog(int nodeId, string msg); 
    }
}