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
    public class VideoResource
    {
        /// <summary>
        /// Whether the video is available, based on various factors
        /// </summary>
        /// <value>Whether the video is available, based on various factors</value>
        [JsonProperty(PropertyName = "active")]
        public bool? Active;

        /// <summary>
        /// The original artist of the media
        /// </summary>
        /// <value>The original artist of the media</value>
        [JsonProperty(PropertyName = "author")]
        public SimpleReferenceResourcelong Author;

        /// <summary>
        /// The date the media was created as a unix timestamp in seconds
        /// </summary>
        /// <value>The date the media was created as a unix timestamp in seconds</value>
        [JsonProperty(PropertyName = "authored")]
        public long? Authored;

        /// <summary>
        /// Whether the video has been banned or not
        /// </summary>
        /// <value>Whether the video has been banned or not</value>
        [JsonProperty(PropertyName = "banned")]
        public bool? Banned;

        /// <summary>
        /// The category of the video
        /// </summary>
        /// <value>The category of the video</value>
        [JsonProperty(PropertyName = "category")]
        public SimpleReferenceResourcestring Category;

        /// <summary>
        /// The comments of the video
        /// </summary>
        /// <value>The comments of the video</value>
        [JsonProperty(PropertyName = "comments")]
        public List<CommentResource> Comments;

        /// <summary>
        /// Artists that contributed to the creation. See separate endpoint to add to list
        /// </summary>
        /// <value>Artists that contributed to the creation. See separate endpoint to add to list</value>
        [JsonProperty(PropertyName = "contributors")]
        public List<ContributionResource> Contributors;

        /// <summary>
        /// The date/time this resource was created in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was created in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "created_date")]
        public long? CreatedDate;

        /// <summary>
        /// The country of an embedable version
        /// </summary>
        /// <value>The country of an embedable version</value>
        [JsonProperty(PropertyName = "embed")]
        public string Embed;

        /// <summary>
        /// The file extension of the media file. 1-5 characters
        /// </summary>
        /// <value>The file extension of the media file. 1-5 characters</value>
        [JsonProperty(PropertyName = "extension")]
        public string Extension;

        /// <summary>
        /// The height of the video in px
        /// </summary>
        /// <value>The height of the video in px</value>
        [JsonProperty(PropertyName = "height")]
        public int? Height;

        /// <summary>
        /// The unique ID for that resource
        /// </summary>
        /// <value>The unique ID for that resource</value>
        [JsonProperty(PropertyName = "id")]
        public long? Id;

        /// <summary>
        /// The length of the video in seconds
        /// </summary>
        /// <value>The length of the video in seconds</value>
        [JsonProperty(PropertyName = "length")]
        public int? Length;

        /// <summary>
        /// The country of the media. Typically a url. Cannot be blank
        /// </summary>
        /// <value>The country of the media. Typically a url. Cannot be blank</value>
        [JsonProperty(PropertyName = "location")]
        public string Location;

        /// <summary>
        /// The user friendly name of that resource. Defaults to blank string
        /// </summary>
        /// <value>The user friendly name of that resource. Defaults to blank string</value>
        [JsonProperty(PropertyName = "long_description")]
        public string LongDescription;

        /// <summary>
        /// The mime-type of the media
        /// </summary>
        /// <value>The mime-type of the media</value>
        [JsonProperty(PropertyName = "mime_type")]
        public string MimeType;

        /// <summary>
        /// The user friendly name of that resource
        /// </summary>
        /// <value>The user friendly name of that resource</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <summary>
        /// The sort order of the video. default: 100
        /// </summary>
        /// <value>The sort order of the video. default: 100</value>
        [JsonProperty(PropertyName = "priority")]
        public int? Priority;

        /// <summary>
        /// The privacy setting. default: private
        /// </summary>
        /// <value>The privacy setting. default: private</value>
        [JsonProperty(PropertyName = "privacy")]
        public string Privacy;

        /// <summary>
        /// Whether the video has been made public. Default true
        /// </summary>
        /// <value>Whether the video has been made public. Default true</value>
        [JsonProperty(PropertyName = "published")]
        public bool? Published;

        /// <summary>
        /// The user friendly name of that resource. Defaults to blank string
        /// </summary>
        /// <value>The user friendly name of that resource. Defaults to blank string</value>
        [JsonProperty(PropertyName = "short_description")]
        public string ShortDescription;

        /// <summary>
        /// The size of the media. Minimum 0 if supplied
        /// </summary>
        /// <value>The size of the media. Minimum 0 if supplied</value>
        [JsonProperty(PropertyName = "size")]
        public long? Size;

        /// <summary>
        /// The tags for the video
        /// </summary>
        /// <value>The tags for the video</value>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags;

        /// <summary>
        /// The country of a thumbnail version. Typically a url
        /// </summary>
        /// <value>The country of a thumbnail version. Typically a url</value>
        [JsonProperty(PropertyName = "thumbnail")]
        public string Thumbnail;

        /// <summary>
        /// The date/time this resource was last updated in seconds since unix epoch
        /// </summary>
        /// <value>The date/time this resource was last updated in seconds since unix epoch</value>
        [JsonProperty(PropertyName = "updated_date")]
        public long? UpdatedDate;

        /// <summary>
        /// The user the media was uploaded by. May be null for system uploaded media. May only be set to a user other than the current caller if VIDEOS_ADMIN permission. Null will mean the caller is the uploader unless the caller has VIDEOS_ADMIN permission, in which case it will be set to null
        /// </summary>
        /// <value>The user the media was uploaded by. May be null for system uploaded media. May only be set to a user other than the current caller if VIDEOS_ADMIN permission. Null will mean the caller is the uploader unless the caller has VIDEOS_ADMIN permission, in which case it will be set to null</value>
        [JsonProperty(PropertyName = "uploader")]
        public SimpleUserResource Uploader;

        /// <summary>
        /// The view count of the video
        /// </summary>
        /// <value>The view count of the video</value>
        [JsonProperty(PropertyName = "views")]
        public long? Views;

        /// <summary>
        /// The width of the video in px
        /// </summary>
        /// <value>The width of the video in px</value>
        [JsonProperty(PropertyName = "width")]
        public int? Width;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class VideoResource {\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  Author: ").Append(Author).Append("\n");
            sb.Append("  Authored: ").Append(Authored).Append("\n");
            sb.Append("  Banned: ").Append(Banned).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Comments: ").Append(Comments).Append("\n");
            sb.Append("  Contributors: ").Append(Contributors).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Embed: ").Append(Embed).Append("\n");
            sb.Append("  Extension: ").Append(Extension).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Length: ").Append(Length).Append("\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("  LongDescription: ").Append(LongDescription).Append("\n");
            sb.Append("  MimeType: ").Append(MimeType).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("  Privacy: ").Append(Privacy).Append("\n");
            sb.Append("  Published: ").Append(Published).Append("\n");
            sb.Append("  ShortDescription: ").Append(ShortDescription).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Thumbnail: ").Append(Thumbnail).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  Uploader: ").Append(Uploader).Append("\n");
            sb.Append("  Views: ").Append(Views).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
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
