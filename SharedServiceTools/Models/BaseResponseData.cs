using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedServiceTools.Models
{
    public class BaseResponseData<TData>
    {
        public BaseResponseData()
        {

        }

        public BaseResponseData(TData data, string marketplaceId)
        {
            this.Data = data;
            this.MarketplaceId = marketplaceId;
        }

        public string MarketplaceId { get; set; }

        public TData Data { get; set; }
    }
}
