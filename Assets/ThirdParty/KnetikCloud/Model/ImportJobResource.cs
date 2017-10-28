using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using com.knetikcloud.Attributes;
using com.knetikcloud.Serialization;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    public class ImportJobResource
    {
        /// <summary>
        /// The id of the category to assign all questions in the import to
        /// </summary>
        /// <value>The id of the category to assign all questions in the import to</value>
        [JsonProperty(PropertyName = "category_id")]
        public string CategoryId;

        /// <summary>
        /// The date the job was created in seconds since unix epoc
        /// </summary>
        /// <value>The date the job was created in seconds since unix epoc</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The id of the job
        /// </summary>
        /// <value>The id of the job</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id;

        /// <summary>
        /// A name for this import for later reference
        /// </summary>
        /// <value>A name for this import for later reference</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// Error information from validation
        /// </summary>
        /// <value>Error information from validation</value>
        [JsonProperty(PropertyName = "output")]
        public List<ImportJobOutputResource> Output;

        /// <summary>
        /// The number of questions form the CSV file. Filled in after validation
        /// </summary>
        /// <value>The number of questions form the CSV file. Filled in after validation</value>
        [JsonProperty(PropertyName = "record_count")]
        public long? RecordCount;

        /// <summary>
        /// The status of the job
        /// </summary>
        /// <value>The status of the job</value>
        [JsonProperty(PropertyName = "status")]
        public string Status;

        /// <summary>
        /// The date the job was last updated in seconds since unix epoc
        /// </summary>
        /// <value>The date the job was last updated in seconds since unix epoc</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <summary>
        /// The url of a CSV file to pull trivia questions from. Cannot be changed after initial POST
        /// </summary>
        /// <value>The url of a CSV file to pull trivia questions from. Cannot be changed after initial POST</value>
        [JsonProperty(PropertyName = "url")]
        public string Url;

        /// <summary>
        /// The vendor who supplied this set of questions
        /// </summary>
        /// <value>The vendor who supplied this set of questions</value>
        [JsonProperty(PropertyName = "vendor")]
        public string Vendor;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ImportJobResource {\n");
            sb.Append("  CategoryId: ").Append(CategoryId).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Output: ").Append(Output).Append("\n");
            sb.Append("  RecordCount: ").Append(RecordCount).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  Vendor: ").Append(Vendor).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
