// <copyright file="GetCalculateInput.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace APIMATICCalculator.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMATICCalculator.Standard;
    using APIMATICCalculator.Standard.Utilities;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// GetCalculateInput.
    /// </summary>
    public class GetCalculateInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCalculateInput"/> class.
        /// </summary>
        public GetCalculateInput()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCalculateInput"/> class.
        /// </summary>
        /// <param name="operation">operation.</param>
        /// <param name="x">x.</param>
        /// <param name="y">y.</param>
        public GetCalculateInput(
            Models.OperationTypeEnum operation,
            double x,
            double y)
        {
            this.Operation = operation;
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// The operator to apply on the variables
        /// </summary>
        [JsonProperty("operation")]
        public Models.OperationTypeEnum Operation { get; set; }

        /// <summary>
        /// The LHS value
        /// </summary>
        [JsonProperty("x")]
        public double X { get; set; }

        /// <summary>
        /// The RHS value
        /// </summary>
        [JsonProperty("y")]
        public double Y { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GetCalculateInput : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is GetCalculateInput other &&                this.Operation.Equals(other.Operation) &&
                this.X.Equals(other.X) &&
                this.Y.Equals(other.Y);
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Operation = {this.Operation}");
            toStringOutput.Add($"this.X = {this.X}");
            toStringOutput.Add($"this.Y = {this.Y}");
        }
    }
}