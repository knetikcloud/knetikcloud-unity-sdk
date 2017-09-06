using System;
using System.Collections.Generic;
using RestSharp;
using com.knetikcloud.Client;
using com.knetikcloud.Model;
using UnityEngine;

using Object = System.Object;
using Version = com.knetikcloud.Model.Version;


namespace com.knetikcloud.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IGamificationTriviaApi
    {
        /// <summary>
        /// Add an answer to a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        /// <param name="answer">The new answer</param>
        /// <returns>AnswerResource</returns>
        AnswerResource AddQuestionAnswers (string questionId, AnswerResource answer);
        /// <summary>
        /// Add a tag to a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <param name="tag">The new tag</param>
        /// <returns></returns>
        void AddQuestionTag (string id, StringWrapper tag);
        /// <summary>
        /// Add a tag to a batch of questions All questions that dont&#39;t have the tag and match filters will have it added. The returned number is the number of questions updated.
        /// </summary>
        /// <param name="tag">The tag to add</param>
        /// <param name="filterSearch">Filter for documents whose question, answers or tags contains provided string</param>
        /// <param name="filterIdset">Filter for documents whose id is in the comma separated list provided</param>
        /// <param name="filterCategory">Filter for questions with specified category, by id</param>
        /// <param name="filterTag">Filter for questions with specified tag</param>
        /// <param name="filterTagset">Filter for questions with specified tags (separated by comma)</param>
        /// <param name="filterType">Filter for questions with specified type</param>
        /// <param name="filterPublished">Filter for questions currenctly published or not</param>
        /// <param name="filterImportId">Filter for questions from a specific import job</param>
        /// <returns>int?</returns>
        int? AddTagToQuestionsBatch (StringWrapper tag, string filterSearch, string filterIdset, string filterCategory, string filterTag, string filterTagset, string filterType, bool? filterPublished, long? filterImportId);
        /// <summary>
        /// Create an import job Set up a job to import a set of trivia questions from a cvs file at a remote url. the file will be validated asynchronously but will not be processed until started manually with the process endpoint.
        /// </summary>
        /// <param name="request">The new import job</param>
        /// <returns>ImportJobResource</returns>
        ImportJobResource CreateImportJob (ImportJobResource request);
        /// <summary>
        /// Create a question 
        /// </summary>
        /// <param name="question">The new question</param>
        /// <returns>QuestionResource</returns>
        QuestionResource CreateQuestion (QuestionResource question);
        /// <summary>
        /// Create a question template Question templates define a type of question and the properties they have
        /// </summary>
        /// <param name="questionTemplateResource">The question template resource object</param>
        /// <returns>QuestionTemplateResource</returns>
        QuestionTemplateResource CreateQuestionTemplate (QuestionTemplateResource questionTemplateResource);
        /// <summary>
        /// Delete an import job Also deletes all questions that were imported by it
        /// </summary>
        /// <param name="id">The id of the job</param>
        /// <returns></returns>
        void DeleteImportJob (long? id);
        /// <summary>
        /// Delete a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <returns></returns>
        void DeleteQuestion (string id);
        /// <summary>
        /// Remove an answer from a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        /// <param name="id">The id of the answer</param>
        /// <returns></returns>
        void DeleteQuestionAnswers (string questionId, string id);
        /// <summary>
        /// Delete a question template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        /// <returns></returns>
        void DeleteQuestionTemplate (string id, string cascade);
        /// <summary>
        /// Get an import job 
        /// </summary>
        /// <param name="id">The id of the job</param>
        /// <returns>ImportJobResource</returns>
        ImportJobResource GetImportJob (long? id);
        /// <summary>
        /// Get a list of import job 
        /// </summary>
        /// <param name="filterVendor">Filter for jobs by vendor id</param>
        /// <param name="filterCategory">Filter for jobs by category id</param>
        /// <param name="filterName">Filter for jobs which name *STARTS* with the given string</param>
        /// <param name="filterStatus">Filter for jobs that are in a specific set of statuses (comma separated)</param>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceImportJobResource</returns>
        PageResourceImportJobResource GetImportJobs (string filterVendor, string filterCategory, string filterName, string filterStatus, int? size, int? page, string order);
        /// <summary>
        /// Get a single question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <returns>QuestionResource</returns>
        QuestionResource GetQuestion (string id);
        /// <summary>
        /// Get an answer for a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        /// <param name="id">The id of the answer</param>
        /// <returns>AnswerResource</returns>
        AnswerResource GetQuestionAnswer (string questionId, string id);
        /// <summary>
        /// List the answers available for a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        /// <returns>List&lt;AnswerResource&gt;</returns>
        List<AnswerResource> GetQuestionAnswers (string questionId);
        /// <summary>
        /// List question deltas in ascending order of updated date The &#39;since&#39; parameter is important to avoid getting a full list of all questions. Implementors should make sure they pass the updated date of the last resource loaded, not the date of the last request, in order to avoid gaps
        /// </summary>
        /// <param name="since">Timestamp in seconds</param>
        /// <returns>List&lt;DeltaResource&gt;</returns>
        List<DeltaResource> GetQuestionDeltas (long? since);
        /// <summary>
        /// List the tags for a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> GetQuestionTags (string id);
        /// <summary>
        /// Get a single question template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <returns>QuestionTemplateResource</returns>
        QuestionTemplateResource GetQuestionTemplate (string id);
        /// <summary>
        /// List and search question templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <returns>PageResourceQuestionTemplateResource</returns>
        PageResourceQuestionTemplateResource GetQuestionTemplates (int? size, int? page, string order);
        /// <summary>
        /// List and search questions 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        /// <param name="filterSearch">Filter for documents whose question, answers or tags contains provided string</param>
        /// <param name="filterIdset">Filter for documents whose id is in the comma separated list provided</param>
        /// <param name="filterCategory">Filter for questions with specified category, by id</param>
        /// <param name="filterTagset">Filter for questions with specified tags (separated by comma)</param>
        /// <param name="filterTag">Filter for questions with specified tag</param>
        /// <param name="filterType">Filter for questions with specified type.  Allowable values: (&#39;TEXT&#39;, &#39;IMAGE&#39;, &#39;VIDEO&#39;, &#39;AUDIO&#39;)</param>
        /// <param name="filterPublished">Filter for questions currenctly published or not</param>
        /// <param name="filterImportId">Filter for questions from a specific import job</param>
        /// <returns>PageResourceQuestionResource</returns>
        PageResourceQuestionResource GetQuestions (int? size, int? page, string order, string filterSearch, string filterIdset, string filterCategory, string filterTagset, string filterTag, string filterType, bool? filterPublished, long? filterImportId);
        /// <summary>
        /// Count questions based on filters This is also provided by the list endpoint so you don&#39;t need to call this for pagination purposes
        /// </summary>
        /// <param name="filterSearch">Filter for documents whose question, answers or tags contains provided string</param>
        /// <param name="filterIdset">Filter for documents whose id is in the comma separated list provided</param>
        /// <param name="filterCategory">Filter for questions with specified category, by id</param>
        /// <param name="filterTag">Filter for questions with specified tag</param>
        /// <param name="filterTagset">Filter for questions with specified tags (separated by comma)</param>
        /// <param name="filterType">Filter for questions with specified type.  Allowable values: (&#39;TEXT&#39;, &#39;IMAGE&#39;, &#39;VIDEO&#39;, &#39;AUDIO&#39;)</param>
        /// <param name="filterPublished">Filter for questions currenctly published or not</param>
        /// <returns>long?</returns>
        long? GetQuestionsCount (string filterSearch, string filterIdset, string filterCategory, string filterTag, string filterTagset, string filterType, bool? filterPublished);
        /// <summary>
        /// Start processing an import job Will process the CSV file and add new questions asynchronously. The status of the job must be &#39;VALID&#39;.
        /// </summary>
        /// <param name="id">The id of the job</param>
        /// <param name="publishNow">Whether the new questions should be published live immediately</param>
        /// <returns>ImportJobResource</returns>
        ImportJobResource ProcessImportJob (long? id, bool? publishNow);
        /// <summary>
        /// Remove a tag from a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <param name="tag">The tag to remove</param>
        /// <returns></returns>
        void RemoveQuestionTag (string id, string tag);
        /// <summary>
        /// Remove a tag from a batch of questions ll questions that have the tag and match filters will have it removed. The returned number is the number of questions updated.
        /// </summary>
        /// <param name="tag">The tag to remove</param>
        /// <param name="filterSearch">Filter for documents whose question, answers or tags contains provided string</param>
        /// <param name="filterIdset">Filter for documents whose id is in the comma separated list provided</param>
        /// <param name="filterCategory">Filter for questions with specified category, by id</param>
        /// <param name="filterTag">Filter for questions with specified tag</param>
        /// <param name="filterTagset">Filter for questions with specified tags (separated by comma)</param>
        /// <param name="filterType">Filter for questions with specified type.  Allowable values: (&#39;TEXT&#39;, &#39;IMAGE&#39;, &#39;VIDEO&#39;, &#39;AUDIO&#39;)</param>
        /// <param name="filterPublished">Filter for questions currenctly published or not</param>
        /// <param name="filterImportId">Filter for questions from a specific import job</param>
        /// <returns>int?</returns>
        int? RemoveTagToQuestionsBatch (string tag, string filterSearch, string filterIdset, string filterCategory, string filterTag, string filterTagset, string filterType, bool? filterPublished, long? filterImportId);
        /// <summary>
        /// List and search tags by the beginning of the string For performance reasons, search &amp; category filters are mutually exclusive. If category is specified, search filter will be ignored in order to do fast matches for typeahead.
        /// </summary>
        /// <param name="filterSearch">Filter for tags starting with the given text</param>
        /// <param name="filterCategory">Filter for tags on questions from a specific category</param>
        /// <param name="filterImportId">Filter for tags on questions from a specific import job</param>
        /// <returns>List&lt;string&gt;</returns>
        List<string> SearchQuestionTags (string filterSearch, string filterCategory, long? filterImportId);
        /// <summary>
        /// Update an import job Changes should be made before process is started for there to be any effect.
        /// </summary>
        /// <param name="id">The id of the job</param>
        /// <param name="request">The updated job</param>
        /// <returns>ImportJobResource</returns>
        ImportJobResource UpdateImportJob (long? id, ImportJobResource request);
        /// <summary>
        /// Update a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <param name="question">The updated question</param>
        /// <returns>QuestionResource</returns>
        QuestionResource UpdateQuestion (string id, QuestionResource question);
        /// <summary>
        /// Update an answer for a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        /// <param name="id">The id of the answer</param>
        /// <param name="answer">The updated answer</param>
        /// <returns></returns>
        void UpdateQuestionAnswer (string questionId, string id, AnswerResource answer);
        /// <summary>
        /// Update a question template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="questionTemplateResource">The question template resource object</param>
        /// <returns>QuestionTemplateResource</returns>
        QuestionTemplateResource UpdateQuestionTemplate (string id, QuestionTemplateResource questionTemplateResource);
        /// <summary>
        /// Bulk update questions Will update all questions that match filters used (or all questions in system if no filters used). Body should match a question resource with only those properties you wish to set. Null values will be ignored. Returned number is how many were updated.
        /// </summary>
        /// <param name="question">New values for a set of question fields</param>
        /// <param name="filterSearch">Filter for documents whose question, answers or tags contains provided string</param>
        /// <param name="filterIdset">Filter for documents whose id is in the comma separated list provided</param>
        /// <param name="filterCategory">Filter for questions with specified category, by id</param>
        /// <param name="filterTagset">Filter for questions with specified tags (separated by comma)</param>
        /// <param name="filterType">Filter for questions with specified type.  Allowable values: (&#39;TEXT&#39;, &#39;IMAGE&#39;, &#39;VIDEO&#39;, &#39;AUDIO&#39;)</param>
        /// <param name="filterPublished">Filter for questions currenctly published or not</param>
        /// <param name="filterImportId">Filter for questions from a specific import job</param>
        /// <returns>int?</returns>
        int? UpdateQuestionsInBulk (QuestionResource question, string filterSearch, string filterIdset, string filterCategory, string filterTagset, string filterType, bool? filterPublished, long? filterImportId);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class GamificationTriviaApi : IGamificationTriviaApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GamificationTriviaApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GamificationTriviaApi()
        {
            KnetikClient = KnetikConfiguration.DefaultClient;
        }
    
        /// <summary>
        /// Gets the Knetik client.
        /// </summary>
        /// <value>An instance of the KnetikClient</value>
        public KnetikClient KnetikClient {get; private set;}

        /// <summary>
        /// Add an answer to a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param> 
        /// <param name="answer">The new answer</param> 
        /// <returns>AnswerResource</returns>            
        public AnswerResource AddQuestionAnswers(string questionId, AnswerResource answer)
        {
            // verify the required parameter 'questionId' is set
            if (questionId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'questionId' when calling AddQuestionAnswers");
            }
            
            
            string urlPath = "/trivia/questions/{question_id}/answers";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "question_id" + "}", KnetikClient.ParameterToString(questionId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(answer); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddQuestionAnswers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddQuestionAnswers: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (AnswerResource) KnetikClient.Deserialize(response.Content, typeof(AnswerResource), response.Headers);
        }
        /// <summary>
        /// Add a tag to a question 
        /// </summary>
        /// <param name="id">The id of the question</param> 
        /// <param name="tag">The new tag</param> 
        /// <returns></returns>            
        public void AddQuestionTag(string id, StringWrapper tag)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AddQuestionTag");
            }
            
            
            string urlPath = "/trivia/questions/{id}/tags";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(tag); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddQuestionTag: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddQuestionTag: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Add a tag to a batch of questions All questions that dont&#39;t have the tag and match filters will have it added. The returned number is the number of questions updated.
        /// </summary>
        /// <param name="tag">The tag to add</param> 
        /// <param name="filterSearch">Filter for documents whose question, answers or tags contains provided string</param> 
        /// <param name="filterIdset">Filter for documents whose id is in the comma separated list provided</param> 
        /// <param name="filterCategory">Filter for questions with specified category, by id</param> 
        /// <param name="filterTag">Filter for questions with specified tag</param> 
        /// <param name="filterTagset">Filter for questions with specified tags (separated by comma)</param> 
        /// <param name="filterType">Filter for questions with specified type</param> 
        /// <param name="filterPublished">Filter for questions currenctly published or not</param> 
        /// <param name="filterImportId">Filter for questions from a specific import job</param> 
        /// <returns>int?</returns>            
        public int? AddTagToQuestionsBatch(StringWrapper tag, string filterSearch, string filterIdset, string filterCategory, string filterTag, string filterTagset, string filterType, bool? filterPublished, long? filterImportId)
        {
            
            string urlPath = "/trivia/questions/tags";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.ParameterToString(filterSearch));
            }
            
            if (filterIdset != null)
            {
                queryParams.Add("filter_idset", KnetikClient.ParameterToString(filterIdset));
            }
            
            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.ParameterToString(filterCategory));
            }
            
            if (filterTag != null)
            {
                queryParams.Add("filter_tag", KnetikClient.ParameterToString(filterTag));
            }
            
            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.ParameterToString(filterTagset));
            }
            
            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.ParameterToString(filterType));
            }
            
            if (filterPublished != null)
            {
                queryParams.Add("filter_published", KnetikClient.ParameterToString(filterPublished));
            }
            
            if (filterImportId != null)
            {
                queryParams.Add("filter_import_id", KnetikClient.ParameterToString(filterImportId));
            }
            
            postBody = KnetikClient.Serialize(tag); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddTagToQuestionsBatch: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling AddTagToQuestionsBatch: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (int?) KnetikClient.Deserialize(response.Content, typeof(int?), response.Headers);
        }
        /// <summary>
        /// Create an import job Set up a job to import a set of trivia questions from a cvs file at a remote url. the file will be validated asynchronously but will not be processed until started manually with the process endpoint.
        /// </summary>
        /// <param name="request">The new import job</param> 
        /// <returns>ImportJobResource</returns>            
        public ImportJobResource CreateImportJob(ImportJobResource request)
        {
            
            string urlPath = "/trivia/import";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateImportJob: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateImportJob: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ImportJobResource) KnetikClient.Deserialize(response.Content, typeof(ImportJobResource), response.Headers);
        }
        /// <summary>
        /// Create a question 
        /// </summary>
        /// <param name="question">The new question</param> 
        /// <returns>QuestionResource</returns>            
        public QuestionResource CreateQuestion(QuestionResource question)
        {
            
            string urlPath = "/trivia/questions";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(question); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateQuestion: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateQuestion: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (QuestionResource) KnetikClient.Deserialize(response.Content, typeof(QuestionResource), response.Headers);
        }
        /// <summary>
        /// Create a question template Question templates define a type of question and the properties they have
        /// </summary>
        /// <param name="questionTemplateResource">The question template resource object</param> 
        /// <returns>QuestionTemplateResource</returns>            
        public QuestionTemplateResource CreateQuestionTemplate(QuestionTemplateResource questionTemplateResource)
        {
            
            string urlPath = "/trivia/questions/templates";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(questionTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateQuestionTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling CreateQuestionTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (QuestionTemplateResource) KnetikClient.Deserialize(response.Content, typeof(QuestionTemplateResource), response.Headers);
        }
        /// <summary>
        /// Delete an import job Also deletes all questions that were imported by it
        /// </summary>
        /// <param name="id">The id of the job</param> 
        /// <returns></returns>            
        public void DeleteImportJob(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteImportJob");
            }
            
            
            string urlPath = "/trivia/import/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteImportJob: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteImportJob: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete a question 
        /// </summary>
        /// <param name="id">The id of the question</param> 
        /// <returns></returns>            
        public void DeleteQuestion(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteQuestion");
            }
            
            
            string urlPath = "/trivia/questions/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteQuestion: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteQuestion: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Remove an answer from a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param> 
        /// <param name="id">The id of the answer</param> 
        /// <returns></returns>            
        public void DeleteQuestionAnswers(string questionId, string id)
        {
            // verify the required parameter 'questionId' is set
            if (questionId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'questionId' when calling DeleteQuestionAnswers");
            }
            
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteQuestionAnswers");
            }
            
            
            string urlPath = "/trivia/questions/{question_id}/answers/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "question_id" + "}", KnetikClient.ParameterToString(questionId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteQuestionAnswers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteQuestionAnswers: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Delete a question template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="cascade">The value needed to delete used templates</param> 
        /// <returns></returns>            
        public void DeleteQuestionTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteQuestionTemplate");
            }
            
            
            string urlPath = "/trivia/questions/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.ParameterToString(cascade));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteQuestionTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling DeleteQuestionTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Get an import job 
        /// </summary>
        /// <param name="id">The id of the job</param> 
        /// <returns>ImportJobResource</returns>            
        public ImportJobResource GetImportJob(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetImportJob");
            }
            
            
            string urlPath = "/trivia/import/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetImportJob: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetImportJob: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ImportJobResource) KnetikClient.Deserialize(response.Content, typeof(ImportJobResource), response.Headers);
        }
        /// <summary>
        /// Get a list of import job 
        /// </summary>
        /// <param name="filterVendor">Filter for jobs by vendor id</param> 
        /// <param name="filterCategory">Filter for jobs by category id</param> 
        /// <param name="filterName">Filter for jobs which name *STARTS* with the given string</param> 
        /// <param name="filterStatus">Filter for jobs that are in a specific set of statuses (comma separated)</param> 
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceImportJobResource</returns>            
        public PageResourceImportJobResource GetImportJobs(string filterVendor, string filterCategory, string filterName, string filterStatus, int? size, int? page, string order)
        {
            
            string urlPath = "/trivia/import";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterVendor != null)
            {
                queryParams.Add("filter_vendor", KnetikClient.ParameterToString(filterVendor));
            }
            
            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.ParameterToString(filterCategory));
            }
            
            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.ParameterToString(filterName));
            }
            
            if (filterStatus != null)
            {
                queryParams.Add("filter_status", KnetikClient.ParameterToString(filterStatus));
            }
            
            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (order != null)
            {
                queryParams.Add("order", KnetikClient.ParameterToString(order));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetImportJobs: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetImportJobs: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceImportJobResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceImportJobResource), response.Headers);
        }
        /// <summary>
        /// Get a single question 
        /// </summary>
        /// <param name="id">The id of the question</param> 
        /// <returns>QuestionResource</returns>            
        public QuestionResource GetQuestion(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetQuestion");
            }
            
            
            string urlPath = "/trivia/questions/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestion: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestion: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (QuestionResource) KnetikClient.Deserialize(response.Content, typeof(QuestionResource), response.Headers);
        }
        /// <summary>
        /// Get an answer for a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param> 
        /// <param name="id">The id of the answer</param> 
        /// <returns>AnswerResource</returns>            
        public AnswerResource GetQuestionAnswer(string questionId, string id)
        {
            // verify the required parameter 'questionId' is set
            if (questionId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'questionId' when calling GetQuestionAnswer");
            }
            
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetQuestionAnswer");
            }
            
            
            string urlPath = "/trivia/questions/{question_id}/answers/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "question_id" + "}", KnetikClient.ParameterToString(questionId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestionAnswer: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestionAnswer: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (AnswerResource) KnetikClient.Deserialize(response.Content, typeof(AnswerResource), response.Headers);
        }
        /// <summary>
        /// List the answers available for a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param> 
        /// <returns>List&lt;AnswerResource&gt;</returns>            
        public List<AnswerResource> GetQuestionAnswers(string questionId)
        {
            // verify the required parameter 'questionId' is set
            if (questionId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'questionId' when calling GetQuestionAnswers");
            }
            
            
            string urlPath = "/trivia/questions/{question_id}/answers";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "question_id" + "}", KnetikClient.ParameterToString(questionId));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestionAnswers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestionAnswers: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<AnswerResource>) KnetikClient.Deserialize(response.Content, typeof(List<AnswerResource>), response.Headers);
        }
        /// <summary>
        /// List question deltas in ascending order of updated date The &#39;since&#39; parameter is important to avoid getting a full list of all questions. Implementors should make sure they pass the updated date of the last resource loaded, not the date of the last request, in order to avoid gaps
        /// </summary>
        /// <param name="since">Timestamp in seconds</param> 
        /// <returns>List&lt;DeltaResource&gt;</returns>            
        public List<DeltaResource> GetQuestionDeltas(long? since)
        {
            
            string urlPath = "/trivia/questions/delta";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (since != null)
            {
                queryParams.Add("since", KnetikClient.ParameterToString(since));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestionDeltas: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestionDeltas: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<DeltaResource>) KnetikClient.Deserialize(response.Content, typeof(List<DeltaResource>), response.Headers);
        }
        /// <summary>
        /// List the tags for a question 
        /// </summary>
        /// <param name="id">The id of the question</param> 
        /// <returns>List&lt;string&gt;</returns>            
        public List<string> GetQuestionTags(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetQuestionTags");
            }
            
            
            string urlPath = "/trivia/questions/{id}/tags";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestionTags: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestionTags: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
        }
        /// <summary>
        /// Get a single question template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <returns>QuestionTemplateResource</returns>            
        public QuestionTemplateResource GetQuestionTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetQuestionTemplate");
            }
            
            
            string urlPath = "/trivia/questions/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestionTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestionTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (QuestionTemplateResource) KnetikClient.Deserialize(response.Content, typeof(QuestionTemplateResource), response.Headers);
        }
        /// <summary>
        /// List and search question templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <returns>PageResourceQuestionTemplateResource</returns>            
        public PageResourceQuestionTemplateResource GetQuestionTemplates(int? size, int? page, string order)
        {
            
            string urlPath = "/trivia/questions/templates";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (order != null)
            {
                queryParams.Add("order", KnetikClient.ParameterToString(order));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestionTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestionTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceQuestionTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceQuestionTemplateResource), response.Headers);
        }
        /// <summary>
        /// List and search questions 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param> 
        /// <param name="page">The number of the page returned, starting with 1</param> 
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param> 
        /// <param name="filterSearch">Filter for documents whose question, answers or tags contains provided string</param> 
        /// <param name="filterIdset">Filter for documents whose id is in the comma separated list provided</param> 
        /// <param name="filterCategory">Filter for questions with specified category, by id</param> 
        /// <param name="filterTagset">Filter for questions with specified tags (separated by comma)</param> 
        /// <param name="filterTag">Filter for questions with specified tag</param> 
        /// <param name="filterType">Filter for questions with specified type.  Allowable values: (&#39;TEXT&#39;, &#39;IMAGE&#39;, &#39;VIDEO&#39;, &#39;AUDIO&#39;)</param> 
        /// <param name="filterPublished">Filter for questions currenctly published or not</param> 
        /// <param name="filterImportId">Filter for questions from a specific import job</param> 
        /// <returns>PageResourceQuestionResource</returns>            
        public PageResourceQuestionResource GetQuestions(int? size, int? page, string order, string filterSearch, string filterIdset, string filterCategory, string filterTagset, string filterTag, string filterType, bool? filterPublished, long? filterImportId)
        {
            
            string urlPath = "/trivia/questions";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.ParameterToString(size));
            }
            
            if (page != null)
            {
                queryParams.Add("page", KnetikClient.ParameterToString(page));
            }
            
            if (order != null)
            {
                queryParams.Add("order", KnetikClient.ParameterToString(order));
            }
            
            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.ParameterToString(filterSearch));
            }
            
            if (filterIdset != null)
            {
                queryParams.Add("filter_idset", KnetikClient.ParameterToString(filterIdset));
            }
            
            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.ParameterToString(filterCategory));
            }
            
            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.ParameterToString(filterTagset));
            }
            
            if (filterTag != null)
            {
                queryParams.Add("filter_tag", KnetikClient.ParameterToString(filterTag));
            }
            
            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.ParameterToString(filterType));
            }
            
            if (filterPublished != null)
            {
                queryParams.Add("filter_published", KnetikClient.ParameterToString(filterPublished));
            }
            
            if (filterImportId != null)
            {
                queryParams.Add("filter_import_id", KnetikClient.ParameterToString(filterImportId));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestions: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (PageResourceQuestionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceQuestionResource), response.Headers);
        }
        /// <summary>
        /// Count questions based on filters This is also provided by the list endpoint so you don&#39;t need to call this for pagination purposes
        /// </summary>
        /// <param name="filterSearch">Filter for documents whose question, answers or tags contains provided string</param> 
        /// <param name="filterIdset">Filter for documents whose id is in the comma separated list provided</param> 
        /// <param name="filterCategory">Filter for questions with specified category, by id</param> 
        /// <param name="filterTag">Filter for questions with specified tag</param> 
        /// <param name="filterTagset">Filter for questions with specified tags (separated by comma)</param> 
        /// <param name="filterType">Filter for questions with specified type.  Allowable values: (&#39;TEXT&#39;, &#39;IMAGE&#39;, &#39;VIDEO&#39;, &#39;AUDIO&#39;)</param> 
        /// <param name="filterPublished">Filter for questions currenctly published or not</param> 
        /// <returns>long?</returns>            
        public long? GetQuestionsCount(string filterSearch, string filterIdset, string filterCategory, string filterTag, string filterTagset, string filterType, bool? filterPublished)
        {
            
            string urlPath = "/trivia/questions/count";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.ParameterToString(filterSearch));
            }
            
            if (filterIdset != null)
            {
                queryParams.Add("filter_idset", KnetikClient.ParameterToString(filterIdset));
            }
            
            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.ParameterToString(filterCategory));
            }
            
            if (filterTag != null)
            {
                queryParams.Add("filter_tag", KnetikClient.ParameterToString(filterTag));
            }
            
            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.ParameterToString(filterTagset));
            }
            
            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.ParameterToString(filterType));
            }
            
            if (filterPublished != null)
            {
                queryParams.Add("filter_published", KnetikClient.ParameterToString(filterPublished));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestionsCount: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling GetQuestionsCount: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (long?) KnetikClient.Deserialize(response.Content, typeof(long?), response.Headers);
        }
        /// <summary>
        /// Start processing an import job Will process the CSV file and add new questions asynchronously. The status of the job must be &#39;VALID&#39;.
        /// </summary>
        /// <param name="id">The id of the job</param> 
        /// <param name="publishNow">Whether the new questions should be published live immediately</param> 
        /// <returns>ImportJobResource</returns>            
        public ImportJobResource ProcessImportJob(long? id, bool? publishNow)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling ProcessImportJob");
            }
            
            // verify the required parameter 'publishNow' is set
            if (publishNow == null)
            {
                throw new KnetikException(400, "Missing required parameter 'publishNow' when calling ProcessImportJob");
            }
            
            
            string urlPath = "/trivia/import/{id}/process";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (publishNow != null)
            {
                queryParams.Add("publish_now", KnetikClient.ParameterToString(publishNow));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling ProcessImportJob: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling ProcessImportJob: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ImportJobResource) KnetikClient.Deserialize(response.Content, typeof(ImportJobResource), response.Headers);
        }
        /// <summary>
        /// Remove a tag from a question 
        /// </summary>
        /// <param name="id">The id of the question</param> 
        /// <param name="tag">The tag to remove</param> 
        /// <returns></returns>            
        public void RemoveQuestionTag(string id, string tag)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling RemoveQuestionTag");
            }
            
            // verify the required parameter 'tag' is set
            if (tag == null)
            {
                throw new KnetikException(400, "Missing required parameter 'tag' when calling RemoveQuestionTag");
            }
            
            
            string urlPath = "/trivia/questions/{id}/tags/{tag}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
urlPath = urlPath.Replace("{" + "tag" + "}", KnetikClient.ParameterToString(tag));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling RemoveQuestionTag: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling RemoveQuestionTag: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Remove a tag from a batch of questions ll questions that have the tag and match filters will have it removed. The returned number is the number of questions updated.
        /// </summary>
        /// <param name="tag">The tag to remove</param> 
        /// <param name="filterSearch">Filter for documents whose question, answers or tags contains provided string</param> 
        /// <param name="filterIdset">Filter for documents whose id is in the comma separated list provided</param> 
        /// <param name="filterCategory">Filter for questions with specified category, by id</param> 
        /// <param name="filterTag">Filter for questions with specified tag</param> 
        /// <param name="filterTagset">Filter for questions with specified tags (separated by comma)</param> 
        /// <param name="filterType">Filter for questions with specified type.  Allowable values: (&#39;TEXT&#39;, &#39;IMAGE&#39;, &#39;VIDEO&#39;, &#39;AUDIO&#39;)</param> 
        /// <param name="filterPublished">Filter for questions currenctly published or not</param> 
        /// <param name="filterImportId">Filter for questions from a specific import job</param> 
        /// <returns>int?</returns>            
        public int? RemoveTagToQuestionsBatch(string tag, string filterSearch, string filterIdset, string filterCategory, string filterTag, string filterTagset, string filterType, bool? filterPublished, long? filterImportId)
        {
            // verify the required parameter 'tag' is set
            if (tag == null)
            {
                throw new KnetikException(400, "Missing required parameter 'tag' when calling RemoveTagToQuestionsBatch");
            }
            
            
            string urlPath = "/trivia/questions/tags/{tag}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "tag" + "}", KnetikClient.ParameterToString(tag));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.ParameterToString(filterSearch));
            }
            
            if (filterIdset != null)
            {
                queryParams.Add("filter_idset", KnetikClient.ParameterToString(filterIdset));
            }
            
            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.ParameterToString(filterCategory));
            }
            
            if (filterTag != null)
            {
                queryParams.Add("filter_tag", KnetikClient.ParameterToString(filterTag));
            }
            
            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.ParameterToString(filterTagset));
            }
            
            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.ParameterToString(filterType));
            }
            
            if (filterPublished != null)
            {
                queryParams.Add("filter_published", KnetikClient.ParameterToString(filterPublished));
            }
            
            if (filterImportId != null)
            {
                queryParams.Add("filter_import_id", KnetikClient.ParameterToString(filterImportId));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling RemoveTagToQuestionsBatch: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling RemoveTagToQuestionsBatch: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (int?) KnetikClient.Deserialize(response.Content, typeof(int?), response.Headers);
        }
        /// <summary>
        /// List and search tags by the beginning of the string For performance reasons, search &amp; category filters are mutually exclusive. If category is specified, search filter will be ignored in order to do fast matches for typeahead.
        /// </summary>
        /// <param name="filterSearch">Filter for tags starting with the given text</param> 
        /// <param name="filterCategory">Filter for tags on questions from a specific category</param> 
        /// <param name="filterImportId">Filter for tags on questions from a specific import job</param> 
        /// <returns>List&lt;string&gt;</returns>            
        public List<string> SearchQuestionTags(string filterSearch, string filterCategory, long? filterImportId)
        {
            
            string urlPath = "/trivia/tags";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.ParameterToString(filterSearch));
            }
            
            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.ParameterToString(filterCategory));
            }
            
            if (filterImportId != null)
            {
                queryParams.Add("filter_import_id", KnetikClient.ParameterToString(filterImportId));
            }
            
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SearchQuestionTags: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling SearchQuestionTags: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
        }
        /// <summary>
        /// Update an import job Changes should be made before process is started for there to be any effect.
        /// </summary>
        /// <param name="id">The id of the job</param> 
        /// <param name="request">The updated job</param> 
        /// <returns>ImportJobResource</returns>            
        public ImportJobResource UpdateImportJob(long? id, ImportJobResource request)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateImportJob");
            }
            
            
            string urlPath = "/trivia/import/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateImportJob: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateImportJob: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (ImportJobResource) KnetikClient.Deserialize(response.Content, typeof(ImportJobResource), response.Headers);
        }
        /// <summary>
        /// Update a question 
        /// </summary>
        /// <param name="id">The id of the question</param> 
        /// <param name="question">The updated question</param> 
        /// <returns>QuestionResource</returns>            
        public QuestionResource UpdateQuestion(string id, QuestionResource question)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateQuestion");
            }
            
            
            string urlPath = "/trivia/questions/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(question); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateQuestion: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateQuestion: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (QuestionResource) KnetikClient.Deserialize(response.Content, typeof(QuestionResource), response.Headers);
        }
        /// <summary>
        /// Update an answer for a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param> 
        /// <param name="id">The id of the answer</param> 
        /// <param name="answer">The updated answer</param> 
        /// <returns></returns>            
        public void UpdateQuestionAnswer(string questionId, string id, AnswerResource answer)
        {
            // verify the required parameter 'questionId' is set
            if (questionId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'questionId' when calling UpdateQuestionAnswer");
            }
            
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateQuestionAnswer");
            }
            
            
            string urlPath = "/trivia/questions/{question_id}/answers/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "question_id" + "}", KnetikClient.ParameterToString(questionId));
urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(answer); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateQuestionAnswer: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateQuestionAnswer: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return;
        }
        /// <summary>
        /// Update a question template 
        /// </summary>
        /// <param name="id">The id of the template</param> 
        /// <param name="questionTemplateResource">The question template resource object</param> 
        /// <returns>QuestionTemplateResource</returns>            
        public QuestionTemplateResource UpdateQuestionTemplate(string id, QuestionTemplateResource questionTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateQuestionTemplate");
            }
            
            
            string urlPath = "/trivia/questions/templates/{id}";
            //urlPath = urlPath.Replace("{format}", "json");
            urlPath = urlPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
    
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            postBody = KnetikClient.Serialize(questionTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateQuestionTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateQuestionTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (QuestionTemplateResource) KnetikClient.Deserialize(response.Content, typeof(QuestionTemplateResource), response.Headers);
        }
        /// <summary>
        /// Bulk update questions Will update all questions that match filters used (or all questions in system if no filters used). Body should match a question resource with only those properties you wish to set. Null values will be ignored. Returned number is how many were updated.
        /// </summary>
        /// <param name="question">New values for a set of question fields</param> 
        /// <param name="filterSearch">Filter for documents whose question, answers or tags contains provided string</param> 
        /// <param name="filterIdset">Filter for documents whose id is in the comma separated list provided</param> 
        /// <param name="filterCategory">Filter for questions with specified category, by id</param> 
        /// <param name="filterTagset">Filter for questions with specified tags (separated by comma)</param> 
        /// <param name="filterType">Filter for questions with specified type.  Allowable values: (&#39;TEXT&#39;, &#39;IMAGE&#39;, &#39;VIDEO&#39;, &#39;AUDIO&#39;)</param> 
        /// <param name="filterPublished">Filter for questions currenctly published or not</param> 
        /// <param name="filterImportId">Filter for questions from a specific import job</param> 
        /// <returns>int?</returns>            
        public int? UpdateQuestionsInBulk(QuestionResource question, string filterSearch, string filterIdset, string filterCategory, string filterTagset, string filterType, bool? filterPublished, long? filterImportId)
        {
            
            string urlPath = "/trivia/questions";
            //urlPath = urlPath.Replace("{format}", "json");
                
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            String postBody = null;

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.ParameterToString(filterSearch));
            }
            
            if (filterIdset != null)
            {
                queryParams.Add("filter_idset", KnetikClient.ParameterToString(filterIdset));
            }
            
            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.ParameterToString(filterCategory));
            }
            
            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.ParameterToString(filterTagset));
            }
            
            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.ParameterToString(filterType));
            }
            
            if (filterPublished != null)
            {
                queryParams.Add("filter_published", KnetikClient.ParameterToString(filterPublished));
            }
            
            if (filterImportId != null)
            {
                queryParams.Add("filter_import_id", KnetikClient.ParameterToString(filterImportId));
            }
            
            postBody = KnetikClient.Serialize(question); // http body (model) parameter
 
            // authentication setting, if any
            String[] authSettings = new String[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            Debug.LogFormat("Knetik Cloud: Calling '{0}'...", urlPath);

            // make the HTTP request
            IRestResponse response = (IRestResponse) KnetikClient.CallApi(urlPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateQuestionsInBulk: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException ((int)response.StatusCode, "Error calling UpdateQuestionsInBulk: " + response.ErrorMessage, response.ErrorMessage);
            }
    
            Debug.LogFormat("Knetik Cloud: '{0}' returned successfully.", urlPath);
            return (int?) KnetikClient.Deserialize(response.Content, typeof(int?), response.Headers);
        }
    }
}
