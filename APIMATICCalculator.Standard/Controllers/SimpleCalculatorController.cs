// <copyright file="SimpleCalculatorController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace APIMATICCalculator.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using APIMATICCalculator.Standard;
    using APIMATICCalculator.Standard.Http.Client;
    using APIMATICCalculator.Standard.Utilities;
    using Newtonsoft.Json.Converters;
    using System.Net.Http;

    /// <summary>
    /// SimpleCalculatorController.
    /// </summary>
    public class SimpleCalculatorController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleCalculatorController"/> class.
        /// </summary>
        internal SimpleCalculatorController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Calculates the expression using the specified operation.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <returns>Returns the double response from the API call.</returns>
        public double GetCalculate(
                Models.GetCalculateInput input)
            => CoreHelper.RunTask(GetCalculateAsync(input));

        /// <summary>
        /// Calculates the expression using the specified operation.
        /// </summary>
        /// <param name="input">Object containing request parameters.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the double response from the API call.</returns>
        public async Task<double> GetCalculateAsync(
                Models.GetCalculateInput input,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<double>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/{operation}")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("operation", ApiHelper.JsonSerialize(input.Operation).Trim('\"')))
                      .Query(_query => _query.Setup("x", input.X))
                      .Query(_query => _query.Setup("y", input.Y))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .Deserializer(_response => double.Parse(_response)))
              .ExecuteAsync(cancellationToken);
    }
}