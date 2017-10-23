using System;
using System.Collections.Generic;
using RestSharp;
using com.knetikcloud.Client;
using com.knetikcloud.Model;
using com.knetikcloud.Utils;
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
        AnswerResource AddQuestionAnswersData { get; }

        int? AddTagToQuestionsBatchData { get; }

        ImportJobResource CreateImportJobData { get; }

        QuestionResource CreateQuestionData { get; }

        QuestionTemplateResource CreateQuestionTemplateData { get; }

        ImportJobResource GetImportJobData { get; }

        PageResourceImportJobResource GetImportJobsData { get; }

        QuestionResource GetQuestionData { get; }

        AnswerResource GetQuestionAnswerData { get; }

        List<AnswerResource> GetQuestionAnswersData { get; }

        List<DeltaResource> GetQuestionDeltasData { get; }

        List<string> GetQuestionTagsData { get; }

        QuestionTemplateResource GetQuestionTemplateData { get; }

        PageResourceQuestionTemplateResource GetQuestionTemplatesData { get; }

        PageResourceQuestionResource GetQuestionsData { get; }

        long? GetQuestionsCountData { get; }

        ImportJobResource ProcessImportJobData { get; }

        int? RemoveTagToQuestionsBatchData { get; }

        List<string> SearchQuestionTagsData { get; }

        ImportJobResource UpdateImportJobData { get; }

        QuestionResource UpdateQuestionData { get; }

        QuestionTemplateResource UpdateQuestionTemplateData { get; }

        int? UpdateQuestionsInBulkData { get; }

        
        /// <summary>
        /// Add an answer to a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        /// <param name="answer">The new answer</param>
        void AddQuestionAnswers(string questionId, AnswerResource answer);

        /// <summary>
        /// Add a tag to a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <param name="tag">The new tag</param>
        void AddQuestionTag(string id, StringWrapper tag);

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
        void AddTagToQuestionsBatch(StringWrapper tag, string filterSearch, string filterIdset, string filterCategory, string filterTag, string filterTagset, string filterType, bool? filterPublished, long? filterImportId);

        /// <summary>
        /// Create an import job Set up a job to import a set of trivia questions from a cvs file at a remote url. the file will be validated asynchronously but will not be processed until started manually with the process endpoint.
        /// </summary>
        /// <param name="request">The new import job</param>
        void CreateImportJob(ImportJobResource request);

        /// <summary>
        /// Create a question 
        /// </summary>
        /// <param name="question">The new question</param>
        void CreateQuestion(QuestionResource question);

        /// <summary>
        /// Create a question template Question templates define a type of question and the properties they have
        /// </summary>
        /// <param name="questionTemplateResource">The question template resource object</param>
        void CreateQuestionTemplate(QuestionTemplateResource questionTemplateResource);

        /// <summary>
        /// Delete an import job Also deletes all questions that were imported by it
        /// </summary>
        /// <param name="id">The id of the job</param>
        void DeleteImportJob(long? id);

        /// <summary>
        /// Delete a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        void DeleteQuestion(string id);

        /// <summary>
        /// Remove an answer from a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        /// <param name="id">The id of the answer</param>
        void DeleteQuestionAnswers(string questionId, string id);

        /// <summary>
        /// Delete a question template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        void DeleteQuestionTemplate(string id, string cascade);

        /// <summary>
        /// Get an import job 
        /// </summary>
        /// <param name="id">The id of the job</param>
        void GetImportJob(long? id);

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
        void GetImportJobs(string filterVendor, string filterCategory, string filterName, string filterStatus, int? size, int? page, string order);

        /// <summary>
        /// Get a single question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        void GetQuestion(string id);

        /// <summary>
        /// Get an answer for a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        /// <param name="id">The id of the answer</param>
        void GetQuestionAnswer(string questionId, string id);

        /// <summary>
        /// List the answers available for a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        void GetQuestionAnswers(string questionId);

        /// <summary>
        /// List question deltas in ascending order of updated date The &#39;since&#39; parameter is important to avoid getting a full list of all questions. Implementors should make sure they pass the updated date of the last resource loaded, not the date of the last request, in order to avoid gaps
        /// </summary>
        /// <param name="since">Timestamp in seconds</param>
        void GetQuestionDeltas(long? since);

        /// <summary>
        /// List the tags for a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        void GetQuestionTags(string id);

        /// <summary>
        /// Get a single question template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetQuestionTemplate(string id);

        /// <summary>
        /// List and search question templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetQuestionTemplates(int? size, int? page, string order);

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
        void GetQuestions(int? size, int? page, string order, string filterSearch, string filterIdset, string filterCategory, string filterTagset, string filterTag, string filterType, bool? filterPublished, long? filterImportId);

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
        void GetQuestionsCount(string filterSearch, string filterIdset, string filterCategory, string filterTag, string filterTagset, string filterType, bool? filterPublished);

        /// <summary>
        /// Start processing an import job Will process the CSV file and add new questions asynchronously. The status of the job must be &#39;VALID&#39;.
        /// </summary>
        /// <param name="id">The id of the job</param>
        /// <param name="publishNow">Whether the new questions should be published live immediately</param>
        void ProcessImportJob(long? id, bool? publishNow);

        /// <summary>
        /// Remove a tag from a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <param name="tag">The tag to remove</param>
        void RemoveQuestionTag(string id, string tag);

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
        void RemoveTagToQuestionsBatch(string tag, string filterSearch, string filterIdset, string filterCategory, string filterTag, string filterTagset, string filterType, bool? filterPublished, long? filterImportId);

        /// <summary>
        /// List and search tags by the beginning of the string For performance reasons, search &amp; category filters are mutually exclusive. If category is specified, search filter will be ignored in order to do fast matches for typeahead.
        /// </summary>
        /// <param name="filterSearch">Filter for tags starting with the given text</param>
        /// <param name="filterCategory">Filter for tags on questions from a specific category</param>
        /// <param name="filterImportId">Filter for tags on questions from a specific import job</param>
        void SearchQuestionTags(string filterSearch, string filterCategory, long? filterImportId);

        /// <summary>
        /// Update an import job Changes should be made before process is started for there to be any effect.
        /// </summary>
        /// <param name="id">The id of the job</param>
        /// <param name="request">The updated job</param>
        void UpdateImportJob(long? id, ImportJobResource request);

        /// <summary>
        /// Update a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <param name="question">The updated question</param>
        void UpdateQuestion(string id, QuestionResource question);

        /// <summary>
        /// Update an answer for a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        /// <param name="id">The id of the answer</param>
        /// <param name="answer">The updated answer</param>
        void UpdateQuestionAnswer(string questionId, string id, AnswerResource answer);

        /// <summary>
        /// Update a question template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="questionTemplateResource">The question template resource object</param>
        void UpdateQuestionTemplate(string id, QuestionTemplateResource questionTemplateResource);

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
        void UpdateQuestionsInBulk(QuestionResource question, string filterSearch, string filterIdset, string filterCategory, string filterTagset, string filterType, bool? filterPublished, long? filterImportId);

    }
  
    /// <inheritdoc />
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class GamificationTriviaApi : IGamificationTriviaApi
    {
        private readonly KnetikCoroutine mAddQuestionAnswersCoroutine;
        private DateTime mAddQuestionAnswersStartTime;
        private string mAddQuestionAnswersPath;
        private readonly KnetikCoroutine mAddQuestionTagCoroutine;
        private DateTime mAddQuestionTagStartTime;
        private string mAddQuestionTagPath;
        private readonly KnetikCoroutine mAddTagToQuestionsBatchCoroutine;
        private DateTime mAddTagToQuestionsBatchStartTime;
        private string mAddTagToQuestionsBatchPath;
        private readonly KnetikCoroutine mCreateImportJobCoroutine;
        private DateTime mCreateImportJobStartTime;
        private string mCreateImportJobPath;
        private readonly KnetikCoroutine mCreateQuestionCoroutine;
        private DateTime mCreateQuestionStartTime;
        private string mCreateQuestionPath;
        private readonly KnetikCoroutine mCreateQuestionTemplateCoroutine;
        private DateTime mCreateQuestionTemplateStartTime;
        private string mCreateQuestionTemplatePath;
        private readonly KnetikCoroutine mDeleteImportJobCoroutine;
        private DateTime mDeleteImportJobStartTime;
        private string mDeleteImportJobPath;
        private readonly KnetikCoroutine mDeleteQuestionCoroutine;
        private DateTime mDeleteQuestionStartTime;
        private string mDeleteQuestionPath;
        private readonly KnetikCoroutine mDeleteQuestionAnswersCoroutine;
        private DateTime mDeleteQuestionAnswersStartTime;
        private string mDeleteQuestionAnswersPath;
        private readonly KnetikCoroutine mDeleteQuestionTemplateCoroutine;
        private DateTime mDeleteQuestionTemplateStartTime;
        private string mDeleteQuestionTemplatePath;
        private readonly KnetikCoroutine mGetImportJobCoroutine;
        private DateTime mGetImportJobStartTime;
        private string mGetImportJobPath;
        private readonly KnetikCoroutine mGetImportJobsCoroutine;
        private DateTime mGetImportJobsStartTime;
        private string mGetImportJobsPath;
        private readonly KnetikCoroutine mGetQuestionCoroutine;
        private DateTime mGetQuestionStartTime;
        private string mGetQuestionPath;
        private readonly KnetikCoroutine mGetQuestionAnswerCoroutine;
        private DateTime mGetQuestionAnswerStartTime;
        private string mGetQuestionAnswerPath;
        private readonly KnetikCoroutine mGetQuestionAnswersCoroutine;
        private DateTime mGetQuestionAnswersStartTime;
        private string mGetQuestionAnswersPath;
        private readonly KnetikCoroutine mGetQuestionDeltasCoroutine;
        private DateTime mGetQuestionDeltasStartTime;
        private string mGetQuestionDeltasPath;
        private readonly KnetikCoroutine mGetQuestionTagsCoroutine;
        private DateTime mGetQuestionTagsStartTime;
        private string mGetQuestionTagsPath;
        private readonly KnetikCoroutine mGetQuestionTemplateCoroutine;
        private DateTime mGetQuestionTemplateStartTime;
        private string mGetQuestionTemplatePath;
        private readonly KnetikCoroutine mGetQuestionTemplatesCoroutine;
        private DateTime mGetQuestionTemplatesStartTime;
        private string mGetQuestionTemplatesPath;
        private readonly KnetikCoroutine mGetQuestionsCoroutine;
        private DateTime mGetQuestionsStartTime;
        private string mGetQuestionsPath;
        private readonly KnetikCoroutine mGetQuestionsCountCoroutine;
        private DateTime mGetQuestionsCountStartTime;
        private string mGetQuestionsCountPath;
        private readonly KnetikCoroutine mProcessImportJobCoroutine;
        private DateTime mProcessImportJobStartTime;
        private string mProcessImportJobPath;
        private readonly KnetikCoroutine mRemoveQuestionTagCoroutine;
        private DateTime mRemoveQuestionTagStartTime;
        private string mRemoveQuestionTagPath;
        private readonly KnetikCoroutine mRemoveTagToQuestionsBatchCoroutine;
        private DateTime mRemoveTagToQuestionsBatchStartTime;
        private string mRemoveTagToQuestionsBatchPath;
        private readonly KnetikCoroutine mSearchQuestionTagsCoroutine;
        private DateTime mSearchQuestionTagsStartTime;
        private string mSearchQuestionTagsPath;
        private readonly KnetikCoroutine mUpdateImportJobCoroutine;
        private DateTime mUpdateImportJobStartTime;
        private string mUpdateImportJobPath;
        private readonly KnetikCoroutine mUpdateQuestionCoroutine;
        private DateTime mUpdateQuestionStartTime;
        private string mUpdateQuestionPath;
        private readonly KnetikCoroutine mUpdateQuestionAnswerCoroutine;
        private DateTime mUpdateQuestionAnswerStartTime;
        private string mUpdateQuestionAnswerPath;
        private readonly KnetikCoroutine mUpdateQuestionTemplateCoroutine;
        private DateTime mUpdateQuestionTemplateStartTime;
        private string mUpdateQuestionTemplatePath;
        private readonly KnetikCoroutine mUpdateQuestionsInBulkCoroutine;
        private DateTime mUpdateQuestionsInBulkStartTime;
        private string mUpdateQuestionsInBulkPath;

        public AnswerResource AddQuestionAnswersData { get; private set; }
        public delegate void AddQuestionAnswersCompleteDelegate(AnswerResource response);
        public AddQuestionAnswersCompleteDelegate AddQuestionAnswersComplete;

        public delegate void AddQuestionTagCompleteDelegate();
        public AddQuestionTagCompleteDelegate AddQuestionTagComplete;

        public int? AddTagToQuestionsBatchData { get; private set; }
        public delegate void AddTagToQuestionsBatchCompleteDelegate(int? response);
        public AddTagToQuestionsBatchCompleteDelegate AddTagToQuestionsBatchComplete;

        public ImportJobResource CreateImportJobData { get; private set; }
        public delegate void CreateImportJobCompleteDelegate(ImportJobResource response);
        public CreateImportJobCompleteDelegate CreateImportJobComplete;

        public QuestionResource CreateQuestionData { get; private set; }
        public delegate void CreateQuestionCompleteDelegate(QuestionResource response);
        public CreateQuestionCompleteDelegate CreateQuestionComplete;

        public QuestionTemplateResource CreateQuestionTemplateData { get; private set; }
        public delegate void CreateQuestionTemplateCompleteDelegate(QuestionTemplateResource response);
        public CreateQuestionTemplateCompleteDelegate CreateQuestionTemplateComplete;

        public delegate void DeleteImportJobCompleteDelegate();
        public DeleteImportJobCompleteDelegate DeleteImportJobComplete;

        public delegate void DeleteQuestionCompleteDelegate();
        public DeleteQuestionCompleteDelegate DeleteQuestionComplete;

        public delegate void DeleteQuestionAnswersCompleteDelegate();
        public DeleteQuestionAnswersCompleteDelegate DeleteQuestionAnswersComplete;

        public delegate void DeleteQuestionTemplateCompleteDelegate();
        public DeleteQuestionTemplateCompleteDelegate DeleteQuestionTemplateComplete;

        public ImportJobResource GetImportJobData { get; private set; }
        public delegate void GetImportJobCompleteDelegate(ImportJobResource response);
        public GetImportJobCompleteDelegate GetImportJobComplete;

        public PageResourceImportJobResource GetImportJobsData { get; private set; }
        public delegate void GetImportJobsCompleteDelegate(PageResourceImportJobResource response);
        public GetImportJobsCompleteDelegate GetImportJobsComplete;

        public QuestionResource GetQuestionData { get; private set; }
        public delegate void GetQuestionCompleteDelegate(QuestionResource response);
        public GetQuestionCompleteDelegate GetQuestionComplete;

        public AnswerResource GetQuestionAnswerData { get; private set; }
        public delegate void GetQuestionAnswerCompleteDelegate(AnswerResource response);
        public GetQuestionAnswerCompleteDelegate GetQuestionAnswerComplete;

        public List<AnswerResource> GetQuestionAnswersData { get; private set; }
        public delegate void GetQuestionAnswersCompleteDelegate(List<AnswerResource> response);
        public GetQuestionAnswersCompleteDelegate GetQuestionAnswersComplete;

        public List<DeltaResource> GetQuestionDeltasData { get; private set; }
        public delegate void GetQuestionDeltasCompleteDelegate(List<DeltaResource> response);
        public GetQuestionDeltasCompleteDelegate GetQuestionDeltasComplete;

        public List<string> GetQuestionTagsData { get; private set; }
        public delegate void GetQuestionTagsCompleteDelegate(List<string> response);
        public GetQuestionTagsCompleteDelegate GetQuestionTagsComplete;

        public QuestionTemplateResource GetQuestionTemplateData { get; private set; }
        public delegate void GetQuestionTemplateCompleteDelegate(QuestionTemplateResource response);
        public GetQuestionTemplateCompleteDelegate GetQuestionTemplateComplete;

        public PageResourceQuestionTemplateResource GetQuestionTemplatesData { get; private set; }
        public delegate void GetQuestionTemplatesCompleteDelegate(PageResourceQuestionTemplateResource response);
        public GetQuestionTemplatesCompleteDelegate GetQuestionTemplatesComplete;

        public PageResourceQuestionResource GetQuestionsData { get; private set; }
        public delegate void GetQuestionsCompleteDelegate(PageResourceQuestionResource response);
        public GetQuestionsCompleteDelegate GetQuestionsComplete;

        public long? GetQuestionsCountData { get; private set; }
        public delegate void GetQuestionsCountCompleteDelegate(long? response);
        public GetQuestionsCountCompleteDelegate GetQuestionsCountComplete;

        public ImportJobResource ProcessImportJobData { get; private set; }
        public delegate void ProcessImportJobCompleteDelegate(ImportJobResource response);
        public ProcessImportJobCompleteDelegate ProcessImportJobComplete;

        public delegate void RemoveQuestionTagCompleteDelegate();
        public RemoveQuestionTagCompleteDelegate RemoveQuestionTagComplete;

        public int? RemoveTagToQuestionsBatchData { get; private set; }
        public delegate void RemoveTagToQuestionsBatchCompleteDelegate(int? response);
        public RemoveTagToQuestionsBatchCompleteDelegate RemoveTagToQuestionsBatchComplete;

        public List<string> SearchQuestionTagsData { get; private set; }
        public delegate void SearchQuestionTagsCompleteDelegate(List<string> response);
        public SearchQuestionTagsCompleteDelegate SearchQuestionTagsComplete;

        public ImportJobResource UpdateImportJobData { get; private set; }
        public delegate void UpdateImportJobCompleteDelegate(ImportJobResource response);
        public UpdateImportJobCompleteDelegate UpdateImportJobComplete;

        public QuestionResource UpdateQuestionData { get; private set; }
        public delegate void UpdateQuestionCompleteDelegate(QuestionResource response);
        public UpdateQuestionCompleteDelegate UpdateQuestionComplete;

        public delegate void UpdateQuestionAnswerCompleteDelegate();
        public UpdateQuestionAnswerCompleteDelegate UpdateQuestionAnswerComplete;

        public QuestionTemplateResource UpdateQuestionTemplateData { get; private set; }
        public delegate void UpdateQuestionTemplateCompleteDelegate(QuestionTemplateResource response);
        public UpdateQuestionTemplateCompleteDelegate UpdateQuestionTemplateComplete;

        public int? UpdateQuestionsInBulkData { get; private set; }
        public delegate void UpdateQuestionsInBulkCompleteDelegate(int? response);
        public UpdateQuestionsInBulkCompleteDelegate UpdateQuestionsInBulkComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="GamificationTriviaApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GamificationTriviaApi()
        {
            mAddQuestionAnswersCoroutine = new KnetikCoroutine();
            mAddQuestionTagCoroutine = new KnetikCoroutine();
            mAddTagToQuestionsBatchCoroutine = new KnetikCoroutine();
            mCreateImportJobCoroutine = new KnetikCoroutine();
            mCreateQuestionCoroutine = new KnetikCoroutine();
            mCreateQuestionTemplateCoroutine = new KnetikCoroutine();
            mDeleteImportJobCoroutine = new KnetikCoroutine();
            mDeleteQuestionCoroutine = new KnetikCoroutine();
            mDeleteQuestionAnswersCoroutine = new KnetikCoroutine();
            mDeleteQuestionTemplateCoroutine = new KnetikCoroutine();
            mGetImportJobCoroutine = new KnetikCoroutine();
            mGetImportJobsCoroutine = new KnetikCoroutine();
            mGetQuestionCoroutine = new KnetikCoroutine();
            mGetQuestionAnswerCoroutine = new KnetikCoroutine();
            mGetQuestionAnswersCoroutine = new KnetikCoroutine();
            mGetQuestionDeltasCoroutine = new KnetikCoroutine();
            mGetQuestionTagsCoroutine = new KnetikCoroutine();
            mGetQuestionTemplateCoroutine = new KnetikCoroutine();
            mGetQuestionTemplatesCoroutine = new KnetikCoroutine();
            mGetQuestionsCoroutine = new KnetikCoroutine();
            mGetQuestionsCountCoroutine = new KnetikCoroutine();
            mProcessImportJobCoroutine = new KnetikCoroutine();
            mRemoveQuestionTagCoroutine = new KnetikCoroutine();
            mRemoveTagToQuestionsBatchCoroutine = new KnetikCoroutine();
            mSearchQuestionTagsCoroutine = new KnetikCoroutine();
            mUpdateImportJobCoroutine = new KnetikCoroutine();
            mUpdateQuestionCoroutine = new KnetikCoroutine();
            mUpdateQuestionAnswerCoroutine = new KnetikCoroutine();
            mUpdateQuestionTemplateCoroutine = new KnetikCoroutine();
            mUpdateQuestionsInBulkCoroutine = new KnetikCoroutine();
        }
    
        /// <inheritdoc />
        /// <summary>
        /// Add an answer to a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        /// <param name="answer">The new answer</param>
        public void AddQuestionAnswers(string questionId, AnswerResource answer)
        {
            // verify the required parameter 'questionId' is set
            if (questionId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'questionId' when calling AddQuestionAnswers");
            }
            
            mAddQuestionAnswersPath = "/trivia/questions/{question_id}/answers";
            if (!string.IsNullOrEmpty(mAddQuestionAnswersPath))
            {
                mAddQuestionAnswersPath = mAddQuestionAnswersPath.Replace("{format}", "json");
            }
            mAddQuestionAnswersPath = mAddQuestionAnswersPath.Replace("{" + "question_id" + "}", KnetikClient.DefaultClient.ParameterToString(questionId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(answer); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddQuestionAnswersStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddQuestionAnswersStartTime, mAddQuestionAnswersPath, "Sending server request...");

            // make the HTTP request
            mAddQuestionAnswersCoroutine.ResponseReceived += AddQuestionAnswersCallback;
            mAddQuestionAnswersCoroutine.Start(mAddQuestionAnswersPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddQuestionAnswersCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddQuestionAnswers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddQuestionAnswers: " + response.ErrorMessage, response.ErrorMessage);
            }

            AddQuestionAnswersData = (AnswerResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(AnswerResource), response.Headers);
            KnetikLogger.LogResponse(mAddQuestionAnswersStartTime, mAddQuestionAnswersPath, string.Format("Response received successfully:\n{0}", AddQuestionAnswersData.ToString()));

            if (AddQuestionAnswersComplete != null)
            {
                AddQuestionAnswersComplete(AddQuestionAnswersData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Add a tag to a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <param name="tag">The new tag</param>
        public void AddQuestionTag(string id, StringWrapper tag)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling AddQuestionTag");
            }
            
            mAddQuestionTagPath = "/trivia/questions/{id}/tags";
            if (!string.IsNullOrEmpty(mAddQuestionTagPath))
            {
                mAddQuestionTagPath = mAddQuestionTagPath.Replace("{format}", "json");
            }
            mAddQuestionTagPath = mAddQuestionTagPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(tag); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddQuestionTagStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddQuestionTagStartTime, mAddQuestionTagPath, "Sending server request...");

            // make the HTTP request
            mAddQuestionTagCoroutine.ResponseReceived += AddQuestionTagCallback;
            mAddQuestionTagCoroutine.Start(mAddQuestionTagPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddQuestionTagCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddQuestionTag: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddQuestionTag: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mAddQuestionTagStartTime, mAddQuestionTagPath, "Response received successfully.");
            if (AddQuestionTagComplete != null)
            {
                AddQuestionTagComplete();
            }
        }

        /// <inheritdoc />
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
        public void AddTagToQuestionsBatch(StringWrapper tag, string filterSearch, string filterIdset, string filterCategory, string filterTag, string filterTagset, string filterType, bool? filterPublished, long? filterImportId)
        {
            
            mAddTagToQuestionsBatchPath = "/trivia/questions/tags";
            if (!string.IsNullOrEmpty(mAddTagToQuestionsBatchPath))
            {
                mAddTagToQuestionsBatchPath = mAddTagToQuestionsBatchPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.DefaultClient.ParameterToString(filterSearch));
            }

            if (filterIdset != null)
            {
                queryParams.Add("filter_idset", KnetikClient.DefaultClient.ParameterToString(filterIdset));
            }

            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.DefaultClient.ParameterToString(filterCategory));
            }

            if (filterTag != null)
            {
                queryParams.Add("filter_tag", KnetikClient.DefaultClient.ParameterToString(filterTag));
            }

            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.DefaultClient.ParameterToString(filterTagset));
            }

            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.DefaultClient.ParameterToString(filterType));
            }

            if (filterPublished != null)
            {
                queryParams.Add("filter_published", KnetikClient.DefaultClient.ParameterToString(filterPublished));
            }

            if (filterImportId != null)
            {
                queryParams.Add("filter_import_id", KnetikClient.DefaultClient.ParameterToString(filterImportId));
            }

            postBody = KnetikClient.DefaultClient.Serialize(tag); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mAddTagToQuestionsBatchStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mAddTagToQuestionsBatchStartTime, mAddTagToQuestionsBatchPath, "Sending server request...");

            // make the HTTP request
            mAddTagToQuestionsBatchCoroutine.ResponseReceived += AddTagToQuestionsBatchCallback;
            mAddTagToQuestionsBatchCoroutine.Start(mAddTagToQuestionsBatchPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void AddTagToQuestionsBatchCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddTagToQuestionsBatch: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling AddTagToQuestionsBatch: " + response.ErrorMessage, response.ErrorMessage);
            }

            AddTagToQuestionsBatchData = (int?) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(int?), response.Headers);
            KnetikLogger.LogResponse(mAddTagToQuestionsBatchStartTime, mAddTagToQuestionsBatchPath, string.Format("Response received successfully:\n{0}", AddTagToQuestionsBatchData.ToString()));

            if (AddTagToQuestionsBatchComplete != null)
            {
                AddTagToQuestionsBatchComplete(AddTagToQuestionsBatchData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create an import job Set up a job to import a set of trivia questions from a cvs file at a remote url. the file will be validated asynchronously but will not be processed until started manually with the process endpoint.
        /// </summary>
        /// <param name="request">The new import job</param>
        public void CreateImportJob(ImportJobResource request)
        {
            
            mCreateImportJobPath = "/trivia/import";
            if (!string.IsNullOrEmpty(mCreateImportJobPath))
            {
                mCreateImportJobPath = mCreateImportJobPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateImportJobStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateImportJobStartTime, mCreateImportJobPath, "Sending server request...");

            // make the HTTP request
            mCreateImportJobCoroutine.ResponseReceived += CreateImportJobCallback;
            mCreateImportJobCoroutine.Start(mCreateImportJobPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateImportJobCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateImportJob: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateImportJob: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateImportJobData = (ImportJobResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ImportJobResource), response.Headers);
            KnetikLogger.LogResponse(mCreateImportJobStartTime, mCreateImportJobPath, string.Format("Response received successfully:\n{0}", CreateImportJobData.ToString()));

            if (CreateImportJobComplete != null)
            {
                CreateImportJobComplete(CreateImportJobData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a question 
        /// </summary>
        /// <param name="question">The new question</param>
        public void CreateQuestion(QuestionResource question)
        {
            
            mCreateQuestionPath = "/trivia/questions";
            if (!string.IsNullOrEmpty(mCreateQuestionPath))
            {
                mCreateQuestionPath = mCreateQuestionPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(question); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateQuestionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateQuestionStartTime, mCreateQuestionPath, "Sending server request...");

            // make the HTTP request
            mCreateQuestionCoroutine.ResponseReceived += CreateQuestionCallback;
            mCreateQuestionCoroutine.Start(mCreateQuestionPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateQuestionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateQuestion: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateQuestion: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateQuestionData = (QuestionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(QuestionResource), response.Headers);
            KnetikLogger.LogResponse(mCreateQuestionStartTime, mCreateQuestionPath, string.Format("Response received successfully:\n{0}", CreateQuestionData.ToString()));

            if (CreateQuestionComplete != null)
            {
                CreateQuestionComplete(CreateQuestionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a question template Question templates define a type of question and the properties they have
        /// </summary>
        /// <param name="questionTemplateResource">The question template resource object</param>
        public void CreateQuestionTemplate(QuestionTemplateResource questionTemplateResource)
        {
            
            mCreateQuestionTemplatePath = "/trivia/questions/templates";
            if (!string.IsNullOrEmpty(mCreateQuestionTemplatePath))
            {
                mCreateQuestionTemplatePath = mCreateQuestionTemplatePath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(questionTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mCreateQuestionTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mCreateQuestionTemplateStartTime, mCreateQuestionTemplatePath, "Sending server request...");

            // make the HTTP request
            mCreateQuestionTemplateCoroutine.ResponseReceived += CreateQuestionTemplateCallback;
            mCreateQuestionTemplateCoroutine.Start(mCreateQuestionTemplatePath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void CreateQuestionTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateQuestionTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling CreateQuestionTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            CreateQuestionTemplateData = (QuestionTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(QuestionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateQuestionTemplateStartTime, mCreateQuestionTemplatePath, string.Format("Response received successfully:\n{0}", CreateQuestionTemplateData.ToString()));

            if (CreateQuestionTemplateComplete != null)
            {
                CreateQuestionTemplateComplete(CreateQuestionTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an import job Also deletes all questions that were imported by it
        /// </summary>
        /// <param name="id">The id of the job</param>
        public void DeleteImportJob(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteImportJob");
            }
            
            mDeleteImportJobPath = "/trivia/import/{id}";
            if (!string.IsNullOrEmpty(mDeleteImportJobPath))
            {
                mDeleteImportJobPath = mDeleteImportJobPath.Replace("{format}", "json");
            }
            mDeleteImportJobPath = mDeleteImportJobPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteImportJobStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteImportJobStartTime, mDeleteImportJobPath, "Sending server request...");

            // make the HTTP request
            mDeleteImportJobCoroutine.ResponseReceived += DeleteImportJobCallback;
            mDeleteImportJobCoroutine.Start(mDeleteImportJobPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteImportJobCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteImportJob: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteImportJob: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteImportJobStartTime, mDeleteImportJobPath, "Response received successfully.");
            if (DeleteImportJobComplete != null)
            {
                DeleteImportJobComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        public void DeleteQuestion(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteQuestion");
            }
            
            mDeleteQuestionPath = "/trivia/questions/{id}";
            if (!string.IsNullOrEmpty(mDeleteQuestionPath))
            {
                mDeleteQuestionPath = mDeleteQuestionPath.Replace("{format}", "json");
            }
            mDeleteQuestionPath = mDeleteQuestionPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteQuestionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteQuestionStartTime, mDeleteQuestionPath, "Sending server request...");

            // make the HTTP request
            mDeleteQuestionCoroutine.ResponseReceived += DeleteQuestionCallback;
            mDeleteQuestionCoroutine.Start(mDeleteQuestionPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteQuestionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteQuestion: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteQuestion: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteQuestionStartTime, mDeleteQuestionPath, "Response received successfully.");
            if (DeleteQuestionComplete != null)
            {
                DeleteQuestionComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Remove an answer from a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        /// <param name="id">The id of the answer</param>
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
            
            mDeleteQuestionAnswersPath = "/trivia/questions/{question_id}/answers/{id}";
            if (!string.IsNullOrEmpty(mDeleteQuestionAnswersPath))
            {
                mDeleteQuestionAnswersPath = mDeleteQuestionAnswersPath.Replace("{format}", "json");
            }
            mDeleteQuestionAnswersPath = mDeleteQuestionAnswersPath.Replace("{" + "question_id" + "}", KnetikClient.DefaultClient.ParameterToString(questionId));
mDeleteQuestionAnswersPath = mDeleteQuestionAnswersPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteQuestionAnswersStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteQuestionAnswersStartTime, mDeleteQuestionAnswersPath, "Sending server request...");

            // make the HTTP request
            mDeleteQuestionAnswersCoroutine.ResponseReceived += DeleteQuestionAnswersCallback;
            mDeleteQuestionAnswersCoroutine.Start(mDeleteQuestionAnswersPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteQuestionAnswersCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteQuestionAnswers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteQuestionAnswers: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteQuestionAnswersStartTime, mDeleteQuestionAnswersPath, "Response received successfully.");
            if (DeleteQuestionAnswersComplete != null)
            {
                DeleteQuestionAnswersComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete a question template If cascade &#x3D; &#39;detach&#39;, it will force delete the template even if it&#39;s attached to other objects
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="cascade">The value needed to delete used templates</param>
        public void DeleteQuestionTemplate(string id, string cascade)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling DeleteQuestionTemplate");
            }
            
            mDeleteQuestionTemplatePath = "/trivia/questions/templates/{id}";
            if (!string.IsNullOrEmpty(mDeleteQuestionTemplatePath))
            {
                mDeleteQuestionTemplatePath = mDeleteQuestionTemplatePath.Replace("{format}", "json");
            }
            mDeleteQuestionTemplatePath = mDeleteQuestionTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (cascade != null)
            {
                queryParams.Add("cascade", KnetikClient.DefaultClient.ParameterToString(cascade));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mDeleteQuestionTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mDeleteQuestionTemplateStartTime, mDeleteQuestionTemplatePath, "Sending server request...");

            // make the HTTP request
            mDeleteQuestionTemplateCoroutine.ResponseReceived += DeleteQuestionTemplateCallback;
            mDeleteQuestionTemplateCoroutine.Start(mDeleteQuestionTemplatePath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void DeleteQuestionTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteQuestionTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling DeleteQuestionTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mDeleteQuestionTemplateStartTime, mDeleteQuestionTemplatePath, "Response received successfully.");
            if (DeleteQuestionTemplateComplete != null)
            {
                DeleteQuestionTemplateComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get an import job 
        /// </summary>
        /// <param name="id">The id of the job</param>
        public void GetImportJob(long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetImportJob");
            }
            
            mGetImportJobPath = "/trivia/import/{id}";
            if (!string.IsNullOrEmpty(mGetImportJobPath))
            {
                mGetImportJobPath = mGetImportJobPath.Replace("{format}", "json");
            }
            mGetImportJobPath = mGetImportJobPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetImportJobStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetImportJobStartTime, mGetImportJobPath, "Sending server request...");

            // make the HTTP request
            mGetImportJobCoroutine.ResponseReceived += GetImportJobCallback;
            mGetImportJobCoroutine.Start(mGetImportJobPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetImportJobCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetImportJob: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetImportJob: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetImportJobData = (ImportJobResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ImportJobResource), response.Headers);
            KnetikLogger.LogResponse(mGetImportJobStartTime, mGetImportJobPath, string.Format("Response received successfully:\n{0}", GetImportJobData.ToString()));

            if (GetImportJobComplete != null)
            {
                GetImportJobComplete(GetImportJobData);
            }
        }

        /// <inheritdoc />
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
        public void GetImportJobs(string filterVendor, string filterCategory, string filterName, string filterStatus, int? size, int? page, string order)
        {
            
            mGetImportJobsPath = "/trivia/import";
            if (!string.IsNullOrEmpty(mGetImportJobsPath))
            {
                mGetImportJobsPath = mGetImportJobsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterVendor != null)
            {
                queryParams.Add("filter_vendor", KnetikClient.DefaultClient.ParameterToString(filterVendor));
            }

            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.DefaultClient.ParameterToString(filterCategory));
            }

            if (filterName != null)
            {
                queryParams.Add("filter_name", KnetikClient.DefaultClient.ParameterToString(filterName));
            }

            if (filterStatus != null)
            {
                queryParams.Add("filter_status", KnetikClient.DefaultClient.ParameterToString(filterStatus));
            }

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            if (order != null)
            {
                queryParams.Add("order", KnetikClient.DefaultClient.ParameterToString(order));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetImportJobsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetImportJobsStartTime, mGetImportJobsPath, "Sending server request...");

            // make the HTTP request
            mGetImportJobsCoroutine.ResponseReceived += GetImportJobsCallback;
            mGetImportJobsCoroutine.Start(mGetImportJobsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetImportJobsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetImportJobs: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetImportJobs: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetImportJobsData = (PageResourceImportJobResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceImportJobResource), response.Headers);
            KnetikLogger.LogResponse(mGetImportJobsStartTime, mGetImportJobsPath, string.Format("Response received successfully:\n{0}", GetImportJobsData.ToString()));

            if (GetImportJobsComplete != null)
            {
                GetImportJobsComplete(GetImportJobsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        public void GetQuestion(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetQuestion");
            }
            
            mGetQuestionPath = "/trivia/questions/{id}";
            if (!string.IsNullOrEmpty(mGetQuestionPath))
            {
                mGetQuestionPath = mGetQuestionPath.Replace("{format}", "json");
            }
            mGetQuestionPath = mGetQuestionPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetQuestionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetQuestionStartTime, mGetQuestionPath, "Sending server request...");

            // make the HTTP request
            mGetQuestionCoroutine.ResponseReceived += GetQuestionCallback;
            mGetQuestionCoroutine.Start(mGetQuestionPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetQuestionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestion: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestion: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetQuestionData = (QuestionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(QuestionResource), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionStartTime, mGetQuestionPath, string.Format("Response received successfully:\n{0}", GetQuestionData.ToString()));

            if (GetQuestionComplete != null)
            {
                GetQuestionComplete(GetQuestionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get an answer for a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        /// <param name="id">The id of the answer</param>
        public void GetQuestionAnswer(string questionId, string id)
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
            
            mGetQuestionAnswerPath = "/trivia/questions/{question_id}/answers/{id}";
            if (!string.IsNullOrEmpty(mGetQuestionAnswerPath))
            {
                mGetQuestionAnswerPath = mGetQuestionAnswerPath.Replace("{format}", "json");
            }
            mGetQuestionAnswerPath = mGetQuestionAnswerPath.Replace("{" + "question_id" + "}", KnetikClient.DefaultClient.ParameterToString(questionId));
mGetQuestionAnswerPath = mGetQuestionAnswerPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetQuestionAnswerStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetQuestionAnswerStartTime, mGetQuestionAnswerPath, "Sending server request...");

            // make the HTTP request
            mGetQuestionAnswerCoroutine.ResponseReceived += GetQuestionAnswerCallback;
            mGetQuestionAnswerCoroutine.Start(mGetQuestionAnswerPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetQuestionAnswerCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestionAnswer: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestionAnswer: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetQuestionAnswerData = (AnswerResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(AnswerResource), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionAnswerStartTime, mGetQuestionAnswerPath, string.Format("Response received successfully:\n{0}", GetQuestionAnswerData.ToString()));

            if (GetQuestionAnswerComplete != null)
            {
                GetQuestionAnswerComplete(GetQuestionAnswerData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List the answers available for a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        public void GetQuestionAnswers(string questionId)
        {
            // verify the required parameter 'questionId' is set
            if (questionId == null)
            {
                throw new KnetikException(400, "Missing required parameter 'questionId' when calling GetQuestionAnswers");
            }
            
            mGetQuestionAnswersPath = "/trivia/questions/{question_id}/answers";
            if (!string.IsNullOrEmpty(mGetQuestionAnswersPath))
            {
                mGetQuestionAnswersPath = mGetQuestionAnswersPath.Replace("{format}", "json");
            }
            mGetQuestionAnswersPath = mGetQuestionAnswersPath.Replace("{" + "question_id" + "}", KnetikClient.DefaultClient.ParameterToString(questionId));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetQuestionAnswersStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetQuestionAnswersStartTime, mGetQuestionAnswersPath, "Sending server request...");

            // make the HTTP request
            mGetQuestionAnswersCoroutine.ResponseReceived += GetQuestionAnswersCallback;
            mGetQuestionAnswersCoroutine.Start(mGetQuestionAnswersPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetQuestionAnswersCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestionAnswers: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestionAnswers: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetQuestionAnswersData = (List<AnswerResource>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<AnswerResource>), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionAnswersStartTime, mGetQuestionAnswersPath, string.Format("Response received successfully:\n{0}", GetQuestionAnswersData.ToString()));

            if (GetQuestionAnswersComplete != null)
            {
                GetQuestionAnswersComplete(GetQuestionAnswersData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List question deltas in ascending order of updated date The &#39;since&#39; parameter is important to avoid getting a full list of all questions. Implementors should make sure they pass the updated date of the last resource loaded, not the date of the last request, in order to avoid gaps
        /// </summary>
        /// <param name="since">Timestamp in seconds</param>
        public void GetQuestionDeltas(long? since)
        {
            
            mGetQuestionDeltasPath = "/trivia/questions/delta";
            if (!string.IsNullOrEmpty(mGetQuestionDeltasPath))
            {
                mGetQuestionDeltasPath = mGetQuestionDeltasPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (since != null)
            {
                queryParams.Add("since", KnetikClient.DefaultClient.ParameterToString(since));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetQuestionDeltasStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetQuestionDeltasStartTime, mGetQuestionDeltasPath, "Sending server request...");

            // make the HTTP request
            mGetQuestionDeltasCoroutine.ResponseReceived += GetQuestionDeltasCallback;
            mGetQuestionDeltasCoroutine.Start(mGetQuestionDeltasPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetQuestionDeltasCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestionDeltas: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestionDeltas: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetQuestionDeltasData = (List<DeltaResource>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<DeltaResource>), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionDeltasStartTime, mGetQuestionDeltasPath, string.Format("Response received successfully:\n{0}", GetQuestionDeltasData.ToString()));

            if (GetQuestionDeltasComplete != null)
            {
                GetQuestionDeltasComplete(GetQuestionDeltasData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List the tags for a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        public void GetQuestionTags(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetQuestionTags");
            }
            
            mGetQuestionTagsPath = "/trivia/questions/{id}/tags";
            if (!string.IsNullOrEmpty(mGetQuestionTagsPath))
            {
                mGetQuestionTagsPath = mGetQuestionTagsPath.Replace("{format}", "json");
            }
            mGetQuestionTagsPath = mGetQuestionTagsPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetQuestionTagsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetQuestionTagsStartTime, mGetQuestionTagsPath, "Sending server request...");

            // make the HTTP request
            mGetQuestionTagsCoroutine.ResponseReceived += GetQuestionTagsCallback;
            mGetQuestionTagsCoroutine.Start(mGetQuestionTagsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetQuestionTagsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestionTags: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestionTags: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetQuestionTagsData = (List<string>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionTagsStartTime, mGetQuestionTagsPath, string.Format("Response received successfully:\n{0}", GetQuestionTagsData.ToString()));

            if (GetQuestionTagsComplete != null)
            {
                GetQuestionTagsComplete(GetQuestionTagsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Get a single question template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        public void GetQuestionTemplate(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling GetQuestionTemplate");
            }
            
            mGetQuestionTemplatePath = "/trivia/questions/templates/{id}";
            if (!string.IsNullOrEmpty(mGetQuestionTemplatePath))
            {
                mGetQuestionTemplatePath = mGetQuestionTemplatePath.Replace("{format}", "json");
            }
            mGetQuestionTemplatePath = mGetQuestionTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetQuestionTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetQuestionTemplateStartTime, mGetQuestionTemplatePath, "Sending server request...");

            // make the HTTP request
            mGetQuestionTemplateCoroutine.ResponseReceived += GetQuestionTemplateCallback;
            mGetQuestionTemplateCoroutine.Start(mGetQuestionTemplatePath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetQuestionTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestionTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestionTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetQuestionTemplateData = (QuestionTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(QuestionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionTemplateStartTime, mGetQuestionTemplatePath, string.Format("Response received successfully:\n{0}", GetQuestionTemplateData.ToString()));

            if (GetQuestionTemplateComplete != null)
            {
                GetQuestionTemplateComplete(GetQuestionTemplateData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search question templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        public void GetQuestionTemplates(int? size, int? page, string order)
        {
            
            mGetQuestionTemplatesPath = "/trivia/questions/templates";
            if (!string.IsNullOrEmpty(mGetQuestionTemplatesPath))
            {
                mGetQuestionTemplatesPath = mGetQuestionTemplatesPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            if (order != null)
            {
                queryParams.Add("order", KnetikClient.DefaultClient.ParameterToString(order));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetQuestionTemplatesStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetQuestionTemplatesStartTime, mGetQuestionTemplatesPath, "Sending server request...");

            // make the HTTP request
            mGetQuestionTemplatesCoroutine.ResponseReceived += GetQuestionTemplatesCallback;
            mGetQuestionTemplatesCoroutine.Start(mGetQuestionTemplatesPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetQuestionTemplatesCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestionTemplates: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestionTemplates: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetQuestionTemplatesData = (PageResourceQuestionTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceQuestionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionTemplatesStartTime, mGetQuestionTemplatesPath, string.Format("Response received successfully:\n{0}", GetQuestionTemplatesData.ToString()));

            if (GetQuestionTemplatesComplete != null)
            {
                GetQuestionTemplatesComplete(GetQuestionTemplatesData);
            }
        }

        /// <inheritdoc />
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
        public void GetQuestions(int? size, int? page, string order, string filterSearch, string filterIdset, string filterCategory, string filterTagset, string filterTag, string filterType, bool? filterPublished, long? filterImportId)
        {
            
            mGetQuestionsPath = "/trivia/questions";
            if (!string.IsNullOrEmpty(mGetQuestionsPath))
            {
                mGetQuestionsPath = mGetQuestionsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (size != null)
            {
                queryParams.Add("size", KnetikClient.DefaultClient.ParameterToString(size));
            }

            if (page != null)
            {
                queryParams.Add("page", KnetikClient.DefaultClient.ParameterToString(page));
            }

            if (order != null)
            {
                queryParams.Add("order", KnetikClient.DefaultClient.ParameterToString(order));
            }

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.DefaultClient.ParameterToString(filterSearch));
            }

            if (filterIdset != null)
            {
                queryParams.Add("filter_idset", KnetikClient.DefaultClient.ParameterToString(filterIdset));
            }

            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.DefaultClient.ParameterToString(filterCategory));
            }

            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.DefaultClient.ParameterToString(filterTagset));
            }

            if (filterTag != null)
            {
                queryParams.Add("filter_tag", KnetikClient.DefaultClient.ParameterToString(filterTag));
            }

            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.DefaultClient.ParameterToString(filterType));
            }

            if (filterPublished != null)
            {
                queryParams.Add("filter_published", KnetikClient.DefaultClient.ParameterToString(filterPublished));
            }

            if (filterImportId != null)
            {
                queryParams.Add("filter_import_id", KnetikClient.DefaultClient.ParameterToString(filterImportId));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetQuestionsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetQuestionsStartTime, mGetQuestionsPath, "Sending server request...");

            // make the HTTP request
            mGetQuestionsCoroutine.ResponseReceived += GetQuestionsCallback;
            mGetQuestionsCoroutine.Start(mGetQuestionsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetQuestionsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestions: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestions: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetQuestionsData = (PageResourceQuestionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(PageResourceQuestionResource), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionsStartTime, mGetQuestionsPath, string.Format("Response received successfully:\n{0}", GetQuestionsData.ToString()));

            if (GetQuestionsComplete != null)
            {
                GetQuestionsComplete(GetQuestionsData);
            }
        }

        /// <inheritdoc />
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
        public void GetQuestionsCount(string filterSearch, string filterIdset, string filterCategory, string filterTag, string filterTagset, string filterType, bool? filterPublished)
        {
            
            mGetQuestionsCountPath = "/trivia/questions/count";
            if (!string.IsNullOrEmpty(mGetQuestionsCountPath))
            {
                mGetQuestionsCountPath = mGetQuestionsCountPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.DefaultClient.ParameterToString(filterSearch));
            }

            if (filterIdset != null)
            {
                queryParams.Add("filter_idset", KnetikClient.DefaultClient.ParameterToString(filterIdset));
            }

            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.DefaultClient.ParameterToString(filterCategory));
            }

            if (filterTag != null)
            {
                queryParams.Add("filter_tag", KnetikClient.DefaultClient.ParameterToString(filterTag));
            }

            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.DefaultClient.ParameterToString(filterTagset));
            }

            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.DefaultClient.ParameterToString(filterType));
            }

            if (filterPublished != null)
            {
                queryParams.Add("filter_published", KnetikClient.DefaultClient.ParameterToString(filterPublished));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mGetQuestionsCountStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mGetQuestionsCountStartTime, mGetQuestionsCountPath, "Sending server request...");

            // make the HTTP request
            mGetQuestionsCountCoroutine.ResponseReceived += GetQuestionsCountCallback;
            mGetQuestionsCountCoroutine.Start(mGetQuestionsCountPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void GetQuestionsCountCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestionsCount: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling GetQuestionsCount: " + response.ErrorMessage, response.ErrorMessage);
            }

            GetQuestionsCountData = (long?) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(long?), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionsCountStartTime, mGetQuestionsCountPath, string.Format("Response received successfully:\n{0}", GetQuestionsCountData.ToString()));

            if (GetQuestionsCountComplete != null)
            {
                GetQuestionsCountComplete(GetQuestionsCountData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Start processing an import job Will process the CSV file and add new questions asynchronously. The status of the job must be &#39;VALID&#39;.
        /// </summary>
        /// <param name="id">The id of the job</param>
        /// <param name="publishNow">Whether the new questions should be published live immediately</param>
        public void ProcessImportJob(long? id, bool? publishNow)
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
            
            mProcessImportJobPath = "/trivia/import/{id}/process";
            if (!string.IsNullOrEmpty(mProcessImportJobPath))
            {
                mProcessImportJobPath = mProcessImportJobPath.Replace("{format}", "json");
            }
            mProcessImportJobPath = mProcessImportJobPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (publishNow != null)
            {
                queryParams.Add("publish_now", KnetikClient.DefaultClient.ParameterToString(publishNow));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mProcessImportJobStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mProcessImportJobStartTime, mProcessImportJobPath, "Sending server request...");

            // make the HTTP request
            mProcessImportJobCoroutine.ResponseReceived += ProcessImportJobCallback;
            mProcessImportJobCoroutine.Start(mProcessImportJobPath, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void ProcessImportJobCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling ProcessImportJob: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling ProcessImportJob: " + response.ErrorMessage, response.ErrorMessage);
            }

            ProcessImportJobData = (ImportJobResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ImportJobResource), response.Headers);
            KnetikLogger.LogResponse(mProcessImportJobStartTime, mProcessImportJobPath, string.Format("Response received successfully:\n{0}", ProcessImportJobData.ToString()));

            if (ProcessImportJobComplete != null)
            {
                ProcessImportJobComplete(ProcessImportJobData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Remove a tag from a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <param name="tag">The tag to remove</param>
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
            
            mRemoveQuestionTagPath = "/trivia/questions/{id}/tags/{tag}";
            if (!string.IsNullOrEmpty(mRemoveQuestionTagPath))
            {
                mRemoveQuestionTagPath = mRemoveQuestionTagPath.Replace("{format}", "json");
            }
            mRemoveQuestionTagPath = mRemoveQuestionTagPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));
mRemoveQuestionTagPath = mRemoveQuestionTagPath.Replace("{" + "tag" + "}", KnetikClient.DefaultClient.ParameterToString(tag));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mRemoveQuestionTagStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mRemoveQuestionTagStartTime, mRemoveQuestionTagPath, "Sending server request...");

            // make the HTTP request
            mRemoveQuestionTagCoroutine.ResponseReceived += RemoveQuestionTagCallback;
            mRemoveQuestionTagCoroutine.Start(mRemoveQuestionTagPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void RemoveQuestionTagCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveQuestionTag: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveQuestionTag: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mRemoveQuestionTagStartTime, mRemoveQuestionTagPath, "Response received successfully.");
            if (RemoveQuestionTagComplete != null)
            {
                RemoveQuestionTagComplete();
            }
        }

        /// <inheritdoc />
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
        public void RemoveTagToQuestionsBatch(string tag, string filterSearch, string filterIdset, string filterCategory, string filterTag, string filterTagset, string filterType, bool? filterPublished, long? filterImportId)
        {
            // verify the required parameter 'tag' is set
            if (tag == null)
            {
                throw new KnetikException(400, "Missing required parameter 'tag' when calling RemoveTagToQuestionsBatch");
            }
            
            mRemoveTagToQuestionsBatchPath = "/trivia/questions/tags/{tag}";
            if (!string.IsNullOrEmpty(mRemoveTagToQuestionsBatchPath))
            {
                mRemoveTagToQuestionsBatchPath = mRemoveTagToQuestionsBatchPath.Replace("{format}", "json");
            }
            mRemoveTagToQuestionsBatchPath = mRemoveTagToQuestionsBatchPath.Replace("{" + "tag" + "}", KnetikClient.DefaultClient.ParameterToString(tag));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.DefaultClient.ParameterToString(filterSearch));
            }

            if (filterIdset != null)
            {
                queryParams.Add("filter_idset", KnetikClient.DefaultClient.ParameterToString(filterIdset));
            }

            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.DefaultClient.ParameterToString(filterCategory));
            }

            if (filterTag != null)
            {
                queryParams.Add("filter_tag", KnetikClient.DefaultClient.ParameterToString(filterTag));
            }

            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.DefaultClient.ParameterToString(filterTagset));
            }

            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.DefaultClient.ParameterToString(filterType));
            }

            if (filterPublished != null)
            {
                queryParams.Add("filter_published", KnetikClient.DefaultClient.ParameterToString(filterPublished));
            }

            if (filterImportId != null)
            {
                queryParams.Add("filter_import_id", KnetikClient.DefaultClient.ParameterToString(filterImportId));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mRemoveTagToQuestionsBatchStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mRemoveTagToQuestionsBatchStartTime, mRemoveTagToQuestionsBatchPath, "Sending server request...");

            // make the HTTP request
            mRemoveTagToQuestionsBatchCoroutine.ResponseReceived += RemoveTagToQuestionsBatchCallback;
            mRemoveTagToQuestionsBatchCoroutine.Start(mRemoveTagToQuestionsBatchPath, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void RemoveTagToQuestionsBatchCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveTagToQuestionsBatch: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling RemoveTagToQuestionsBatch: " + response.ErrorMessage, response.ErrorMessage);
            }

            RemoveTagToQuestionsBatchData = (int?) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(int?), response.Headers);
            KnetikLogger.LogResponse(mRemoveTagToQuestionsBatchStartTime, mRemoveTagToQuestionsBatchPath, string.Format("Response received successfully:\n{0}", RemoveTagToQuestionsBatchData.ToString()));

            if (RemoveTagToQuestionsBatchComplete != null)
            {
                RemoveTagToQuestionsBatchComplete(RemoveTagToQuestionsBatchData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List and search tags by the beginning of the string For performance reasons, search &amp; category filters are mutually exclusive. If category is specified, search filter will be ignored in order to do fast matches for typeahead.
        /// </summary>
        /// <param name="filterSearch">Filter for tags starting with the given text</param>
        /// <param name="filterCategory">Filter for tags on questions from a specific category</param>
        /// <param name="filterImportId">Filter for tags on questions from a specific import job</param>
        public void SearchQuestionTags(string filterSearch, string filterCategory, long? filterImportId)
        {
            
            mSearchQuestionTagsPath = "/trivia/tags";
            if (!string.IsNullOrEmpty(mSearchQuestionTagsPath))
            {
                mSearchQuestionTagsPath = mSearchQuestionTagsPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.DefaultClient.ParameterToString(filterSearch));
            }

            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.DefaultClient.ParameterToString(filterCategory));
            }

            if (filterImportId != null)
            {
                queryParams.Add("filter_import_id", KnetikClient.DefaultClient.ParameterToString(filterImportId));
            }

            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mSearchQuestionTagsStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mSearchQuestionTagsStartTime, mSearchQuestionTagsPath, "Sending server request...");

            // make the HTTP request
            mSearchQuestionTagsCoroutine.ResponseReceived += SearchQuestionTagsCallback;
            mSearchQuestionTagsCoroutine.Start(mSearchQuestionTagsPath, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void SearchQuestionTagsCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SearchQuestionTags: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling SearchQuestionTags: " + response.ErrorMessage, response.ErrorMessage);
            }

            SearchQuestionTagsData = (List<string>) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mSearchQuestionTagsStartTime, mSearchQuestionTagsPath, string.Format("Response received successfully:\n{0}", SearchQuestionTagsData.ToString()));

            if (SearchQuestionTagsComplete != null)
            {
                SearchQuestionTagsComplete(SearchQuestionTagsData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an import job Changes should be made before process is started for there to be any effect.
        /// </summary>
        /// <param name="id">The id of the job</param>
        /// <param name="request">The updated job</param>
        public void UpdateImportJob(long? id, ImportJobResource request)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateImportJob");
            }
            
            mUpdateImportJobPath = "/trivia/import/{id}";
            if (!string.IsNullOrEmpty(mUpdateImportJobPath))
            {
                mUpdateImportJobPath = mUpdateImportJobPath.Replace("{format}", "json");
            }
            mUpdateImportJobPath = mUpdateImportJobPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(request); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateImportJobStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateImportJobStartTime, mUpdateImportJobPath, "Sending server request...");

            // make the HTTP request
            mUpdateImportJobCoroutine.ResponseReceived += UpdateImportJobCallback;
            mUpdateImportJobCoroutine.Start(mUpdateImportJobPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateImportJobCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateImportJob: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateImportJob: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateImportJobData = (ImportJobResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(ImportJobResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateImportJobStartTime, mUpdateImportJobPath, string.Format("Response received successfully:\n{0}", UpdateImportJobData.ToString()));

            if (UpdateImportJobComplete != null)
            {
                UpdateImportJobComplete(UpdateImportJobData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <param name="question">The updated question</param>
        public void UpdateQuestion(string id, QuestionResource question)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateQuestion");
            }
            
            mUpdateQuestionPath = "/trivia/questions/{id}";
            if (!string.IsNullOrEmpty(mUpdateQuestionPath))
            {
                mUpdateQuestionPath = mUpdateQuestionPath.Replace("{format}", "json");
            }
            mUpdateQuestionPath = mUpdateQuestionPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(question); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateQuestionStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateQuestionStartTime, mUpdateQuestionPath, "Sending server request...");

            // make the HTTP request
            mUpdateQuestionCoroutine.ResponseReceived += UpdateQuestionCallback;
            mUpdateQuestionCoroutine.Start(mUpdateQuestionPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateQuestionCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateQuestion: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateQuestion: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateQuestionData = (QuestionResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(QuestionResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateQuestionStartTime, mUpdateQuestionPath, string.Format("Response received successfully:\n{0}", UpdateQuestionData.ToString()));

            if (UpdateQuestionComplete != null)
            {
                UpdateQuestionComplete(UpdateQuestionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update an answer for a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        /// <param name="id">The id of the answer</param>
        /// <param name="answer">The updated answer</param>
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
            
            mUpdateQuestionAnswerPath = "/trivia/questions/{question_id}/answers/{id}";
            if (!string.IsNullOrEmpty(mUpdateQuestionAnswerPath))
            {
                mUpdateQuestionAnswerPath = mUpdateQuestionAnswerPath.Replace("{format}", "json");
            }
            mUpdateQuestionAnswerPath = mUpdateQuestionAnswerPath.Replace("{" + "question_id" + "}", KnetikClient.DefaultClient.ParameterToString(questionId));
mUpdateQuestionAnswerPath = mUpdateQuestionAnswerPath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(answer); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateQuestionAnswerStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateQuestionAnswerStartTime, mUpdateQuestionAnswerPath, "Sending server request...");

            // make the HTTP request
            mUpdateQuestionAnswerCoroutine.ResponseReceived += UpdateQuestionAnswerCallback;
            mUpdateQuestionAnswerCoroutine.Start(mUpdateQuestionAnswerPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateQuestionAnswerCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateQuestionAnswer: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateQuestionAnswer: " + response.ErrorMessage, response.ErrorMessage);
            }

            KnetikLogger.LogResponse(mUpdateQuestionAnswerStartTime, mUpdateQuestionAnswerPath, "Response received successfully.");
            if (UpdateQuestionAnswerComplete != null)
            {
                UpdateQuestionAnswerComplete();
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Update a question template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="questionTemplateResource">The question template resource object</param>
        public void UpdateQuestionTemplate(string id, QuestionTemplateResource questionTemplateResource)
        {
            // verify the required parameter 'id' is set
            if (id == null)
            {
                throw new KnetikException(400, "Missing required parameter 'id' when calling UpdateQuestionTemplate");
            }
            
            mUpdateQuestionTemplatePath = "/trivia/questions/templates/{id}";
            if (!string.IsNullOrEmpty(mUpdateQuestionTemplatePath))
            {
                mUpdateQuestionTemplatePath = mUpdateQuestionTemplatePath.Replace("{format}", "json");
            }
            mUpdateQuestionTemplatePath = mUpdateQuestionTemplatePath.Replace("{" + "id" + "}", KnetikClient.DefaultClient.ParameterToString(id));

            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            postBody = KnetikClient.DefaultClient.Serialize(questionTemplateResource); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateQuestionTemplateStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateQuestionTemplateStartTime, mUpdateQuestionTemplatePath, "Sending server request...");

            // make the HTTP request
            mUpdateQuestionTemplateCoroutine.ResponseReceived += UpdateQuestionTemplateCallback;
            mUpdateQuestionTemplateCoroutine.Start(mUpdateQuestionTemplatePath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateQuestionTemplateCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateQuestionTemplate: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateQuestionTemplate: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateQuestionTemplateData = (QuestionTemplateResource) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(QuestionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateQuestionTemplateStartTime, mUpdateQuestionTemplatePath, string.Format("Response received successfully:\n{0}", UpdateQuestionTemplateData.ToString()));

            if (UpdateQuestionTemplateComplete != null)
            {
                UpdateQuestionTemplateComplete(UpdateQuestionTemplateData);
            }
        }

        /// <inheritdoc />
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
        public void UpdateQuestionsInBulk(QuestionResource question, string filterSearch, string filterIdset, string filterCategory, string filterTagset, string filterType, bool? filterPublished, long? filterImportId)
        {
            
            mUpdateQuestionsInBulkPath = "/trivia/questions";
            if (!string.IsNullOrEmpty(mUpdateQuestionsInBulkPath))
            {
                mUpdateQuestionsInBulkPath = mUpdateQuestionsInBulkPath.Replace("{format}", "json");
            }
            
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> headerParams = new Dictionary<string, string>();
            Dictionary<string, string> formParams = new Dictionary<string, string>();
            Dictionary<string, FileParameter> fileParams = new Dictionary<string, FileParameter>();
            string postBody = null;

            if (filterSearch != null)
            {
                queryParams.Add("filter_search", KnetikClient.DefaultClient.ParameterToString(filterSearch));
            }

            if (filterIdset != null)
            {
                queryParams.Add("filter_idset", KnetikClient.DefaultClient.ParameterToString(filterIdset));
            }

            if (filterCategory != null)
            {
                queryParams.Add("filter_category", KnetikClient.DefaultClient.ParameterToString(filterCategory));
            }

            if (filterTagset != null)
            {
                queryParams.Add("filter_tagset", KnetikClient.DefaultClient.ParameterToString(filterTagset));
            }

            if (filterType != null)
            {
                queryParams.Add("filter_type", KnetikClient.DefaultClient.ParameterToString(filterType));
            }

            if (filterPublished != null)
            {
                queryParams.Add("filter_published", KnetikClient.DefaultClient.ParameterToString(filterPublished));
            }

            if (filterImportId != null)
            {
                queryParams.Add("filter_import_id", KnetikClient.DefaultClient.ParameterToString(filterImportId));
            }

            postBody = KnetikClient.DefaultClient.Serialize(question); // http body (model) parameter
 
            // authentication setting, if any
            string[] authSettings = new string[] {  "oauth2_client_credentials_grant", "oauth2_password_grant" };

            mUpdateQuestionsInBulkStartTime = DateTime.Now;
            KnetikLogger.LogRequest(mUpdateQuestionsInBulkStartTime, mUpdateQuestionsInBulkPath, "Sending server request...");

            // make the HTTP request
            mUpdateQuestionsInBulkCoroutine.ResponseReceived += UpdateQuestionsInBulkCallback;
            mUpdateQuestionsInBulkCoroutine.Start(mUpdateQuestionsInBulkPath, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
        }

        private void UpdateQuestionsInBulkCallback(IRestResponse response)
        {
            if (((int)response.StatusCode) >= 400)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateQuestionsInBulk: " + response.Content, response.Content);
            }
            else if (((int)response.StatusCode) == 0)
            {
                throw new KnetikException((int)response.StatusCode, "Error calling UpdateQuestionsInBulk: " + response.ErrorMessage, response.ErrorMessage);
            }

            UpdateQuestionsInBulkData = (int?) KnetikClient.DefaultClient.Deserialize(response.Content, typeof(int?), response.Headers);
            KnetikLogger.LogResponse(mUpdateQuestionsInBulkStartTime, mUpdateQuestionsInBulkPath, string.Format("Response received successfully:\n{0}", UpdateQuestionsInBulkData.ToString()));

            if (UpdateQuestionsInBulkComplete != null)
            {
                UpdateQuestionsInBulkComplete(UpdateQuestionsInBulkData);
            }
        }

    }
}
