using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webbpay.Api.PaymentService.Adapters.Inventory.AdapterModels
{

    public class ProductDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public IList<MetadataDto> MetaData { get; set; }
        public IList<ProductImage> Images { get; set; }
        public IList<Category> Categories { get; set; }
    }

    public class MetadataDto
    {
        public string Key { get; set; }
        public string Content { get; set; }
    }

    public class ProductImage
    {
        public string ImageId { get; set; }
        public string Url { get; set; }
        public string LargeUrl { get; set; }
        public string MediumUrl { get; set; }
        public string SmallUrl { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
    }

}
