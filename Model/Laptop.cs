using CSA.Model;
using System;
using System.Xml.Linq;

namespace CSA.Model
{
    public class Laptop
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string model { get; set; }
        public string firm { get; set; }
        public double price { get; set; }
        public double inch { get; set; }

        public BaseModelValidationResult Validate()
        {
            var validationResult = new BaseModelValidationResult();

            if (string.IsNullOrWhiteSpace(model)) validationResult.Append($"Model cannot be empty");
            if (string.IsNullOrWhiteSpace(firm)) validationResult.Append($"Firm cannot be empty");
            //if (!(price > 0 && price < 1000000)) validationResult.Append($"Price {price} is out of range");
            if (!(inch > 0 && inch < 1000000)) validationResult.Append($"Inch {inch} is out of range");
            return validationResult;
        }

        public override string ToString()
        {
            return $"{model} {firm} from {price}-{inch}";
        }
    }
}
