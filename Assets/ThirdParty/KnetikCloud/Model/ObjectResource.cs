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
    
    
    public class ObjectResource
    {
        /// <summary>
        /// The behaviors linked to the item, describing various options and interactions. May not be included in item lists
        /// </summary>
        /// <value>The behaviors linked to the item, describing various options and interactions. May not be included in item lists</value>
        [JsonProperty(PropertyName = "behaviors")]
        public List<Behavior> Behaviors;

        /// <summary>
        /// A category for filtering items
        /// </summary>
        /// <value>A category for filtering items</value>
        [JsonProperty(PropertyName = "category")]
        public string Category;

        /// <summary>
        /// The date the item was created, unix timestamp in seconds
        /// </summary>
        /// <value>The date the item was created, unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// A map of additional data. The template will define requirements for the object
        /// </summary>
        /// <value>A map of additional data. The template will define requirements for the object</value>
        [JsonProperty(PropertyName = "data")]
        public Object Data;

        /// <summary>
        /// The id of the item
        /// </summary>
        /// <value>The id of the item</value>
        [JsonProperty(PropertyName = "id")]
        public int? Id;

        /// <summary>
        /// A long description of the item
        /// </summary>
        /// <value>A long description of the item</value>
        [JsonProperty(PropertyName = "long_description")]
        public string LongDescription;

        /// <summary>
        /// The name of the item
        /// </summary>
        /// <value>The name of the item</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// A short description of the item, max 255 chars
        /// </summary>
        /// <value>A short description of the item, max 255 chars</value>
        [JsonProperty(PropertyName = "short_description")]
        public string ShortDescription;

        /// <summary>
        /// A number to use in sorting items.  Default 500
        /// </summary>
        /// <value>A number to use in sorting items.  Default 500</value>
        [JsonProperty(PropertyName = "sort")]
        public int? Sort;

        /// <summary>
        /// List of tags used for filtering items
        /// </summary>
        /// <value>List of tags used for filtering items</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags;

        /// <summary>
        /// The unique key for the item
        /// </summary>
        /// <value>The unique key for the item</value>
        [JsonProperty(PropertyName = "unique_key")]
        public string UniqueKey;

        /// <summary>
        /// The date the item was last updated, unix timestamp in seconds
        /// </summary>
        /// <value>The date the item was last updated, unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ObjectResource {\n");
            sb.Append("  Behaviors: ").Append(Behaviors).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LongDescription: ").Append(LongDescription).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ShortDescription: ").Append(ShortDescription).Append("\n");
            sb.Append("  Sort: ").Append(Sort).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  UniqueKey: ").Append(UniqueKey).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
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
