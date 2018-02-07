using System;
using System.Collections.Generic;
using com.knetikcloud.Model;
using KnetikUnity.Client;
using KnetikUnity.Events;
using KnetikUnity.Exceptions;
using KnetikUnity.Utils;

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

        int? AddTagToQuestionsBatchData { get; }

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

        ImportJobResource CreateImportJobData { get; }

        /// <summary>
        /// Create an import job Set up a job to import a set of trivia questions from a cvs file at a remote url. the file will be validated asynchronously but will not be processed until started manually with the process endpoint.
        /// </summary>
        /// <param name="request">The new import job</param>
        void CreateImportJob(ImportJobResource request);

        QuestionResource CreateQuestionData { get; }

        /// <summary>
        /// Create a question 
        /// </summary>
        /// <param name="question">The new question</param>
        void CreateQuestion(QuestionResource question);

        QuestionTemplateResource CreateQuestionTemplateData { get; }

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

        ImportJobResource GetImportJobData { get; }

        /// <summary>
        /// Get an import job 
        /// </summary>
        /// <param name="id">The id of the job</param>
        void GetImportJob(long? id);

        PageResourceImportJobResource GetImportJobsData { get; }

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

        QuestionResource GetQuestionData { get; }

        /// <summary>
        /// Get a single question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        void GetQuestion(string id);

        AnswerResource GetQuestionAnswerData { get; }

        /// <summary>
        /// Get an answer for a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        /// <param name="id">The id of the answer</param>
        void GetQuestionAnswer(string questionId, string id);

        List<AnswerResource> GetQuestionAnswersData { get; }

        /// <summary>
        /// List the answers available for a question 
        /// </summary>
        /// <param name="questionId">The id of the question</param>
        void GetQuestionAnswers(string questionId);

        List<DeltaResource> GetQuestionDeltasData { get; }

        /// <summary>
        /// List question deltas in ascending order of updated date The &#39;since&#39; parameter is important to avoid getting a full list of all questions. Implementors should make sure they pass the updated date of the last resource loaded, not the date of the last request, in order to avoid gaps
        /// </summary>
        /// <param name="since">Timestamp in seconds</param>
        void GetQuestionDeltas(long? since);

        List<string> GetQuestionTagsData { get; }

        /// <summary>
        /// List the tags for a question 
        /// </summary>
        /// <param name="id">The id of the question</param>
        void GetQuestionTags(string id);

        QuestionTemplateResource GetQuestionTemplateData { get; }

        /// <summary>
        /// Get a single question template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        void GetQuestionTemplate(string id);

        PageResourceQuestionTemplateResource GetQuestionTemplatesData { get; }

        /// <summary>
        /// List and search question templates 
        /// </summary>
        /// <param name="size">The number of objects returned per page</param>
        /// <param name="page">The number of the page returned, starting with 1</param>
        /// <param name="order">A comma separated list of sorting requirements in priority order, each entry matching PROPERTY_NAME:[ASC|DESC]</param>
        void GetQuestionTemplates(int? size, int? page, string order);

        PageResourceQuestionResource GetQuestionsData { get; }

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

        long? GetQuestionsCountData { get; }

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

        ImportJobResource ProcessImportJobData { get; }

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

        int? RemoveTagToQuestionsBatchData { get; }

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

        List<string> SearchQuestionTagsData { get; }

        /// <summary>
        /// List and search tags by the beginning of the string For performance reasons, search &amp; category filters are mutually exclusive. If category is specified, search filter will be ignored in order to do fast matches for typeahead.
        /// </summary>
        /// <param name="filterSearch">Filter for tags starting with the given text</param>
        /// <param name="filterCategory">Filter for tags on questions from a specific category</param>
        /// <param name="filterImportId">Filter for tags on questions from a specific import job</param>
        void SearchQuestionTags(string filterSearch, string filterCategory, long? filterImportId);

        ImportJobResource UpdateImportJobData { get; }

        /// <summary>
        /// Update an import job Changes should be made before process is started for there to be any effect.
        /// </summary>
        /// <param name="id">The id of the job</param>
        /// <param name="request">The updated job</param>
        void UpdateImportJob(long? id, ImportJobResource request);

        QuestionResource UpdateQuestionData { get; }

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

        QuestionTemplateResource UpdateQuestionTemplateData { get; }

        /// <summary>
        /// Update a question template 
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="questionTemplateResource">The question template resource object</param>
        void UpdateQuestionTemplate(string id, QuestionTemplateResource questionTemplateResource);

        int? UpdateQuestionsInBulkData { get; }

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
        private readonly KnetikWebCallEvent mWebCallEvent = new KnetikWebCallEvent();

        private readonly KnetikResponseContext mAddQuestionAnswersResponseContext;
        private DateTime mAddQuestionAnswersStartTime;
        private readonly KnetikResponseContext mAddQuestionTagResponseContext;
        private DateTime mAddQuestionTagStartTime;
        private readonly KnetikResponseContext mAddTagToQuestionsBatchResponseContext;
        private DateTime mAddTagToQuestionsBatchStartTime;
        private readonly KnetikResponseContext mCreateImportJobResponseContext;
        private DateTime mCreateImportJobStartTime;
        private readonly KnetikResponseContext mCreateQuestionResponseContext;
        private DateTime mCreateQuestionStartTime;
        private readonly KnetikResponseContext mCreateQuestionTemplateResponseContext;
        private DateTime mCreateQuestionTemplateStartTime;
        private readonly KnetikResponseContext mDeleteImportJobResponseContext;
        private DateTime mDeleteImportJobStartTime;
        private readonly KnetikResponseContext mDeleteQuestionResponseContext;
        private DateTime mDeleteQuestionStartTime;
        private readonly KnetikResponseContext mDeleteQuestionAnswersResponseContext;
        private DateTime mDeleteQuestionAnswersStartTime;
        private readonly KnetikResponseContext mDeleteQuestionTemplateResponseContext;
        private DateTime mDeleteQuestionTemplateStartTime;
        private readonly KnetikResponseContext mGetImportJobResponseContext;
        private DateTime mGetImportJobStartTime;
        private readonly KnetikResponseContext mGetImportJobsResponseContext;
        private DateTime mGetImportJobsStartTime;
        private readonly KnetikResponseContext mGetQuestionResponseContext;
        private DateTime mGetQuestionStartTime;
        private readonly KnetikResponseContext mGetQuestionAnswerResponseContext;
        private DateTime mGetQuestionAnswerStartTime;
        private readonly KnetikResponseContext mGetQuestionAnswersResponseContext;
        private DateTime mGetQuestionAnswersStartTime;
        private readonly KnetikResponseContext mGetQuestionDeltasResponseContext;
        private DateTime mGetQuestionDeltasStartTime;
        private readonly KnetikResponseContext mGetQuestionTagsResponseContext;
        private DateTime mGetQuestionTagsStartTime;
        private readonly KnetikResponseContext mGetQuestionTemplateResponseContext;
        private DateTime mGetQuestionTemplateStartTime;
        private readonly KnetikResponseContext mGetQuestionTemplatesResponseContext;
        private DateTime mGetQuestionTemplatesStartTime;
        private readonly KnetikResponseContext mGetQuestionsResponseContext;
        private DateTime mGetQuestionsStartTime;
        private readonly KnetikResponseContext mGetQuestionsCountResponseContext;
        private DateTime mGetQuestionsCountStartTime;
        private readonly KnetikResponseContext mProcessImportJobResponseContext;
        private DateTime mProcessImportJobStartTime;
        private readonly KnetikResponseContext mRemoveQuestionTagResponseContext;
        private DateTime mRemoveQuestionTagStartTime;
        private readonly KnetikResponseContext mRemoveTagToQuestionsBatchResponseContext;
        private DateTime mRemoveTagToQuestionsBatchStartTime;
        private readonly KnetikResponseContext mSearchQuestionTagsResponseContext;
        private DateTime mSearchQuestionTagsStartTime;
        private readonly KnetikResponseContext mUpdateImportJobResponseContext;
        private DateTime mUpdateImportJobStartTime;
        private readonly KnetikResponseContext mUpdateQuestionResponseContext;
        private DateTime mUpdateQuestionStartTime;
        private readonly KnetikResponseContext mUpdateQuestionAnswerResponseContext;
        private DateTime mUpdateQuestionAnswerStartTime;
        private readonly KnetikResponseContext mUpdateQuestionTemplateResponseContext;
        private DateTime mUpdateQuestionTemplateStartTime;
        private readonly KnetikResponseContext mUpdateQuestionsInBulkResponseContext;
        private DateTime mUpdateQuestionsInBulkStartTime;

        public AnswerResource AddQuestionAnswersData { get; private set; }
        public delegate void AddQuestionAnswersCompleteDelegate(long responseCode, AnswerResource response);
        public AddQuestionAnswersCompleteDelegate AddQuestionAnswersComplete;

        public delegate void AddQuestionTagCompleteDelegate(long responseCode);
        public AddQuestionTagCompleteDelegate AddQuestionTagComplete;

        public int? AddTagToQuestionsBatchData { get; private set; }
        public delegate void AddTagToQuestionsBatchCompleteDelegate(long responseCode, int? response);
        public AddTagToQuestionsBatchCompleteDelegate AddTagToQuestionsBatchComplete;

        public ImportJobResource CreateImportJobData { get; private set; }
        public delegate void CreateImportJobCompleteDelegate(long responseCode, ImportJobResource response);
        public CreateImportJobCompleteDelegate CreateImportJobComplete;

        public QuestionResource CreateQuestionData { get; private set; }
        public delegate void CreateQuestionCompleteDelegate(long responseCode, QuestionResource response);
        public CreateQuestionCompleteDelegate CreateQuestionComplete;

        public QuestionTemplateResource CreateQuestionTemplateData { get; private set; }
        public delegate void CreateQuestionTemplateCompleteDelegate(long responseCode, QuestionTemplateResource response);
        public CreateQuestionTemplateCompleteDelegate CreateQuestionTemplateComplete;

        public delegate void DeleteImportJobCompleteDelegate(long responseCode);
        public DeleteImportJobCompleteDelegate DeleteImportJobComplete;

        public delegate void DeleteQuestionCompleteDelegate(long responseCode);
        public DeleteQuestionCompleteDelegate DeleteQuestionComplete;

        public delegate void DeleteQuestionAnswersCompleteDelegate(long responseCode);
        public DeleteQuestionAnswersCompleteDelegate DeleteQuestionAnswersComplete;

        public delegate void DeleteQuestionTemplateCompleteDelegate(long responseCode);
        public DeleteQuestionTemplateCompleteDelegate DeleteQuestionTemplateComplete;

        public ImportJobResource GetImportJobData { get; private set; }
        public delegate void GetImportJobCompleteDelegate(long responseCode, ImportJobResource response);
        public GetImportJobCompleteDelegate GetImportJobComplete;

        public PageResourceImportJobResource GetImportJobsData { get; private set; }
        public delegate void GetImportJobsCompleteDelegate(long responseCode, PageResourceImportJobResource response);
        public GetImportJobsCompleteDelegate GetImportJobsComplete;

        public QuestionResource GetQuestionData { get; private set; }
        public delegate void GetQuestionCompleteDelegate(long responseCode, QuestionResource response);
        public GetQuestionCompleteDelegate GetQuestionComplete;

        public AnswerResource GetQuestionAnswerData { get; private set; }
        public delegate void GetQuestionAnswerCompleteDelegate(long responseCode, AnswerResource response);
        public GetQuestionAnswerCompleteDelegate GetQuestionAnswerComplete;

        public List<AnswerResource> GetQuestionAnswersData { get; private set; }
        public delegate void GetQuestionAnswersCompleteDelegate(long responseCode, List<AnswerResource> response);
        public GetQuestionAnswersCompleteDelegate GetQuestionAnswersComplete;

        public List<DeltaResource> GetQuestionDeltasData { get; private set; }
        public delegate void GetQuestionDeltasCompleteDelegate(long responseCode, List<DeltaResource> response);
        public GetQuestionDeltasCompleteDelegate GetQuestionDeltasComplete;

        public List<string> GetQuestionTagsData { get; private set; }
        public delegate void GetQuestionTagsCompleteDelegate(long responseCode, List<string> response);
        public GetQuestionTagsCompleteDelegate GetQuestionTagsComplete;

        public QuestionTemplateResource GetQuestionTemplateData { get; private set; }
        public delegate void GetQuestionTemplateCompleteDelegate(long responseCode, QuestionTemplateResource response);
        public GetQuestionTemplateCompleteDelegate GetQuestionTemplateComplete;

        public PageResourceQuestionTemplateResource GetQuestionTemplatesData { get; private set; }
        public delegate void GetQuestionTemplatesCompleteDelegate(long responseCode, PageResourceQuestionTemplateResource response);
        public GetQuestionTemplatesCompleteDelegate GetQuestionTemplatesComplete;

        public PageResourceQuestionResource GetQuestionsData { get; private set; }
        public delegate void GetQuestionsCompleteDelegate(long responseCode, PageResourceQuestionResource response);
        public GetQuestionsCompleteDelegate GetQuestionsComplete;

        public long? GetQuestionsCountData { get; private set; }
        public delegate void GetQuestionsCountCompleteDelegate(long responseCode, long? response);
        public GetQuestionsCountCompleteDelegate GetQuestionsCountComplete;

        public ImportJobResource ProcessImportJobData { get; private set; }
        public delegate void ProcessImportJobCompleteDelegate(long responseCode, ImportJobResource response);
        public ProcessImportJobCompleteDelegate ProcessImportJobComplete;

        public delegate void RemoveQuestionTagCompleteDelegate(long responseCode);
        public RemoveQuestionTagCompleteDelegate RemoveQuestionTagComplete;

        public int? RemoveTagToQuestionsBatchData { get; private set; }
        public delegate void RemoveTagToQuestionsBatchCompleteDelegate(long responseCode, int? response);
        public RemoveTagToQuestionsBatchCompleteDelegate RemoveTagToQuestionsBatchComplete;

        public List<string> SearchQuestionTagsData { get; private set; }
        public delegate void SearchQuestionTagsCompleteDelegate(long responseCode, List<string> response);
        public SearchQuestionTagsCompleteDelegate SearchQuestionTagsComplete;

        public ImportJobResource UpdateImportJobData { get; private set; }
        public delegate void UpdateImportJobCompleteDelegate(long responseCode, ImportJobResource response);
        public UpdateImportJobCompleteDelegate UpdateImportJobComplete;

        public QuestionResource UpdateQuestionData { get; private set; }
        public delegate void UpdateQuestionCompleteDelegate(long responseCode, QuestionResource response);
        public UpdateQuestionCompleteDelegate UpdateQuestionComplete;

        public delegate void UpdateQuestionAnswerCompleteDelegate(long responseCode);
        public UpdateQuestionAnswerCompleteDelegate UpdateQuestionAnswerComplete;

        public QuestionTemplateResource UpdateQuestionTemplateData { get; private set; }
        public delegate void UpdateQuestionTemplateCompleteDelegate(long responseCode, QuestionTemplateResource response);
        public UpdateQuestionTemplateCompleteDelegate UpdateQuestionTemplateComplete;

        public int? UpdateQuestionsInBulkData { get; private set; }
        public delegate void UpdateQuestionsInBulkCompleteDelegate(long responseCode, int? response);
        public UpdateQuestionsInBulkCompleteDelegate UpdateQuestionsInBulkComplete;

        /// <summary>
        /// Initializes a new instance of the <see cref="GamificationTriviaApi"/> class.
        /// </summary>
        /// <returns></returns>
        public GamificationTriviaApi()
        {
            mAddQuestionAnswersResponseContext = new KnetikResponseContext();
            mAddQuestionAnswersResponseContext.ResponseReceived += OnAddQuestionAnswersResponse;
            mAddQuestionTagResponseContext = new KnetikResponseContext();
            mAddQuestionTagResponseContext.ResponseReceived += OnAddQuestionTagResponse;
            mAddTagToQuestionsBatchResponseContext = new KnetikResponseContext();
            mAddTagToQuestionsBatchResponseContext.ResponseReceived += OnAddTagToQuestionsBatchResponse;
            mCreateImportJobResponseContext = new KnetikResponseContext();
            mCreateImportJobResponseContext.ResponseReceived += OnCreateImportJobResponse;
            mCreateQuestionResponseContext = new KnetikResponseContext();
            mCreateQuestionResponseContext.ResponseReceived += OnCreateQuestionResponse;
            mCreateQuestionTemplateResponseContext = new KnetikResponseContext();
            mCreateQuestionTemplateResponseContext.ResponseReceived += OnCreateQuestionTemplateResponse;
            mDeleteImportJobResponseContext = new KnetikResponseContext();
            mDeleteImportJobResponseContext.ResponseReceived += OnDeleteImportJobResponse;
            mDeleteQuestionResponseContext = new KnetikResponseContext();
            mDeleteQuestionResponseContext.ResponseReceived += OnDeleteQuestionResponse;
            mDeleteQuestionAnswersResponseContext = new KnetikResponseContext();
            mDeleteQuestionAnswersResponseContext.ResponseReceived += OnDeleteQuestionAnswersResponse;
            mDeleteQuestionTemplateResponseContext = new KnetikResponseContext();
            mDeleteQuestionTemplateResponseContext.ResponseReceived += OnDeleteQuestionTemplateResponse;
            mGetImportJobResponseContext = new KnetikResponseContext();
            mGetImportJobResponseContext.ResponseReceived += OnGetImportJobResponse;
            mGetImportJobsResponseContext = new KnetikResponseContext();
            mGetImportJobsResponseContext.ResponseReceived += OnGetImportJobsResponse;
            mGetQuestionResponseContext = new KnetikResponseContext();
            mGetQuestionResponseContext.ResponseReceived += OnGetQuestionResponse;
            mGetQuestionAnswerResponseContext = new KnetikResponseContext();
            mGetQuestionAnswerResponseContext.ResponseReceived += OnGetQuestionAnswerResponse;
            mGetQuestionAnswersResponseContext = new KnetikResponseContext();
            mGetQuestionAnswersResponseContext.ResponseReceived += OnGetQuestionAnswersResponse;
            mGetQuestionDeltasResponseContext = new KnetikResponseContext();
            mGetQuestionDeltasResponseContext.ResponseReceived += OnGetQuestionDeltasResponse;
            mGetQuestionTagsResponseContext = new KnetikResponseContext();
            mGetQuestionTagsResponseContext.ResponseReceived += OnGetQuestionTagsResponse;
            mGetQuestionTemplateResponseContext = new KnetikResponseContext();
            mGetQuestionTemplateResponseContext.ResponseReceived += OnGetQuestionTemplateResponse;
            mGetQuestionTemplatesResponseContext = new KnetikResponseContext();
            mGetQuestionTemplatesResponseContext.ResponseReceived += OnGetQuestionTemplatesResponse;
            mGetQuestionsResponseContext = new KnetikResponseContext();
            mGetQuestionsResponseContext.ResponseReceived += OnGetQuestionsResponse;
            mGetQuestionsCountResponseContext = new KnetikResponseContext();
            mGetQuestionsCountResponseContext.ResponseReceived += OnGetQuestionsCountResponse;
            mProcessImportJobResponseContext = new KnetikResponseContext();
            mProcessImportJobResponseContext.ResponseReceived += OnProcessImportJobResponse;
            mRemoveQuestionTagResponseContext = new KnetikResponseContext();
            mRemoveQuestionTagResponseContext.ResponseReceived += OnRemoveQuestionTagResponse;
            mRemoveTagToQuestionsBatchResponseContext = new KnetikResponseContext();
            mRemoveTagToQuestionsBatchResponseContext.ResponseReceived += OnRemoveTagToQuestionsBatchResponse;
            mSearchQuestionTagsResponseContext = new KnetikResponseContext();
            mSearchQuestionTagsResponseContext.ResponseReceived += OnSearchQuestionTagsResponse;
            mUpdateImportJobResponseContext = new KnetikResponseContext();
            mUpdateImportJobResponseContext.ResponseReceived += OnUpdateImportJobResponse;
            mUpdateQuestionResponseContext = new KnetikResponseContext();
            mUpdateQuestionResponseContext.ResponseReceived += OnUpdateQuestionResponse;
            mUpdateQuestionAnswerResponseContext = new KnetikResponseContext();
            mUpdateQuestionAnswerResponseContext.ResponseReceived += OnUpdateQuestionAnswerResponse;
            mUpdateQuestionTemplateResponseContext = new KnetikResponseContext();
            mUpdateQuestionTemplateResponseContext.ResponseReceived += OnUpdateQuestionTemplateResponse;
            mUpdateQuestionsInBulkResponseContext = new KnetikResponseContext();
            mUpdateQuestionsInBulkResponseContext.ResponseReceived += OnUpdateQuestionsInBulkResponse;
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
            
            mWebCallEvent.WebPath = "/trivia/questions/{question_id}/answers";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "question_id" + "}", KnetikClient.ParameterToString(questionId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(answer); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddQuestionAnswersStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddQuestionAnswersResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddQuestionAnswersStartTime, "AddQuestionAnswers", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddQuestionAnswersResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddQuestionAnswers: " + response.Error);
            }

            AddQuestionAnswersData = (AnswerResource) KnetikClient.Deserialize(response.Content, typeof(AnswerResource), response.Headers);
            KnetikLogger.LogResponse(mAddQuestionAnswersStartTime, "AddQuestionAnswers", string.Format("Response received successfully:\n{0}", AddQuestionAnswersData));

            if (AddQuestionAnswersComplete != null)
            {
                AddQuestionAnswersComplete(response.ResponseCode, AddQuestionAnswersData);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/{id}/tags";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(tag); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddQuestionTagStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddQuestionTagResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddQuestionTagStartTime, "AddQuestionTag", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddQuestionTagResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddQuestionTag: " + response.Error);
            }

            KnetikLogger.LogResponse(mAddQuestionTagStartTime, "AddQuestionTag", "Response received successfully.");
            if (AddQuestionTagComplete != null)
            {
                AddQuestionTagComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/tags";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterSearch != null)
            {
                mWebCallEvent.QueryParams["filter_search"] = KnetikClient.ParameterToString(filterSearch);
            }

            if (filterIdset != null)
            {
                mWebCallEvent.QueryParams["filter_idset"] = KnetikClient.ParameterToString(filterIdset);
            }

            if (filterCategory != null)
            {
                mWebCallEvent.QueryParams["filter_category"] = KnetikClient.ParameterToString(filterCategory);
            }

            if (filterTag != null)
            {
                mWebCallEvent.QueryParams["filter_tag"] = KnetikClient.ParameterToString(filterTag);
            }

            if (filterTagset != null)
            {
                mWebCallEvent.QueryParams["filter_tagset"] = KnetikClient.ParameterToString(filterTagset);
            }

            if (filterType != null)
            {
                mWebCallEvent.QueryParams["filter_type"] = KnetikClient.ParameterToString(filterType);
            }

            if (filterPublished != null)
            {
                mWebCallEvent.QueryParams["filter_published"] = KnetikClient.ParameterToString(filterPublished);
            }

            if (filterImportId != null)
            {
                mWebCallEvent.QueryParams["filter_import_id"] = KnetikClient.ParameterToString(filterImportId);
            }

            mWebCallEvent.PostBody = KnetikClient.Serialize(tag); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mAddTagToQuestionsBatchStartTime = DateTime.Now;
            mWebCallEvent.Context = mAddTagToQuestionsBatchResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mAddTagToQuestionsBatchStartTime, "AddTagToQuestionsBatch", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnAddTagToQuestionsBatchResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling AddTagToQuestionsBatch: " + response.Error);
            }

            AddTagToQuestionsBatchData = (int?) KnetikClient.Deserialize(response.Content, typeof(int?), response.Headers);
            KnetikLogger.LogResponse(mAddTagToQuestionsBatchStartTime, "AddTagToQuestionsBatch", string.Format("Response received successfully:\n{0}", AddTagToQuestionsBatchData));

            if (AddTagToQuestionsBatchComplete != null)
            {
                AddTagToQuestionsBatchComplete(response.ResponseCode, AddTagToQuestionsBatchData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create an import job Set up a job to import a set of trivia questions from a cvs file at a remote url. the file will be validated asynchronously but will not be processed until started manually with the process endpoint.
        /// </summary>
        /// <param name="request">The new import job</param>
        public void CreateImportJob(ImportJobResource request)
        {
            
            mWebCallEvent.WebPath = "/trivia/import";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(request); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateImportJobStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateImportJobResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateImportJobStartTime, "CreateImportJob", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateImportJobResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateImportJob: " + response.Error);
            }

            CreateImportJobData = (ImportJobResource) KnetikClient.Deserialize(response.Content, typeof(ImportJobResource), response.Headers);
            KnetikLogger.LogResponse(mCreateImportJobStartTime, "CreateImportJob", string.Format("Response received successfully:\n{0}", CreateImportJobData));

            if (CreateImportJobComplete != null)
            {
                CreateImportJobComplete(response.ResponseCode, CreateImportJobData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a question 
        /// </summary>
        /// <param name="question">The new question</param>
        public void CreateQuestion(QuestionResource question)
        {
            
            mWebCallEvent.WebPath = "/trivia/questions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(question); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateQuestionStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateQuestionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateQuestionStartTime, "CreateQuestion", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateQuestionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateQuestion: " + response.Error);
            }

            CreateQuestionData = (QuestionResource) KnetikClient.Deserialize(response.Content, typeof(QuestionResource), response.Headers);
            KnetikLogger.LogResponse(mCreateQuestionStartTime, "CreateQuestion", string.Format("Response received successfully:\n{0}", CreateQuestionData));

            if (CreateQuestionComplete != null)
            {
                CreateQuestionComplete(response.ResponseCode, CreateQuestionData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a question template Question templates define a type of question and the properties they have
        /// </summary>
        /// <param name="questionTemplateResource">The question template resource object</param>
        public void CreateQuestionTemplate(QuestionTemplateResource questionTemplateResource)
        {
            
            mWebCallEvent.WebPath = "/trivia/questions/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(questionTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mCreateQuestionTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mCreateQuestionTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mCreateQuestionTemplateStartTime, "CreateQuestionTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnCreateQuestionTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling CreateQuestionTemplate: " + response.Error);
            }

            CreateQuestionTemplateData = (QuestionTemplateResource) KnetikClient.Deserialize(response.Content, typeof(QuestionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mCreateQuestionTemplateStartTime, "CreateQuestionTemplate", string.Format("Response received successfully:\n{0}", CreateQuestionTemplateData));

            if (CreateQuestionTemplateComplete != null)
            {
                CreateQuestionTemplateComplete(response.ResponseCode, CreateQuestionTemplateData);
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
            
            mWebCallEvent.WebPath = "/trivia/import/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteImportJobStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteImportJobResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteImportJobStartTime, "DeleteImportJob", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteImportJobResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteImportJob: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteImportJobStartTime, "DeleteImportJob", "Response received successfully.");
            if (DeleteImportJobComplete != null)
            {
                DeleteImportJobComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteQuestionStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteQuestionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteQuestionStartTime, "DeleteQuestion", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteQuestionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteQuestion: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteQuestionStartTime, "DeleteQuestion", "Response received successfully.");
            if (DeleteQuestionComplete != null)
            {
                DeleteQuestionComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/{question_id}/answers/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "question_id" + "}", KnetikClient.ParameterToString(questionId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteQuestionAnswersStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteQuestionAnswersResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteQuestionAnswersStartTime, "DeleteQuestionAnswers", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteQuestionAnswersResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteQuestionAnswers: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteQuestionAnswersStartTime, "DeleteQuestionAnswers", "Response received successfully.");
            if (DeleteQuestionAnswersComplete != null)
            {
                DeleteQuestionAnswersComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (cascade != null)
            {
                mWebCallEvent.QueryParams["cascade"] = KnetikClient.ParameterToString(cascade);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mDeleteQuestionTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mDeleteQuestionTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mDeleteQuestionTemplateStartTime, "DeleteQuestionTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnDeleteQuestionTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling DeleteQuestionTemplate: " + response.Error);
            }

            KnetikLogger.LogResponse(mDeleteQuestionTemplateStartTime, "DeleteQuestionTemplate", "Response received successfully.");
            if (DeleteQuestionTemplateComplete != null)
            {
                DeleteQuestionTemplateComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/trivia/import/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetImportJobStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetImportJobResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetImportJobStartTime, "GetImportJob", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetImportJobResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetImportJob: " + response.Error);
            }

            GetImportJobData = (ImportJobResource) KnetikClient.Deserialize(response.Content, typeof(ImportJobResource), response.Headers);
            KnetikLogger.LogResponse(mGetImportJobStartTime, "GetImportJob", string.Format("Response received successfully:\n{0}", GetImportJobData));

            if (GetImportJobComplete != null)
            {
                GetImportJobComplete(response.ResponseCode, GetImportJobData);
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
            
            mWebCallEvent.WebPath = "/trivia/import";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterVendor != null)
            {
                mWebCallEvent.QueryParams["filter_vendor"] = KnetikClient.ParameterToString(filterVendor);
            }

            if (filterCategory != null)
            {
                mWebCallEvent.QueryParams["filter_category"] = KnetikClient.ParameterToString(filterCategory);
            }

            if (filterName != null)
            {
                mWebCallEvent.QueryParams["filter_name"] = KnetikClient.ParameterToString(filterName);
            }

            if (filterStatus != null)
            {
                mWebCallEvent.QueryParams["filter_status"] = KnetikClient.ParameterToString(filterStatus);
            }

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (order != null)
            {
                mWebCallEvent.QueryParams["order"] = KnetikClient.ParameterToString(order);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetImportJobsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetImportJobsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetImportJobsStartTime, "GetImportJobs", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetImportJobsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetImportJobs: " + response.Error);
            }

            GetImportJobsData = (PageResourceImportJobResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceImportJobResource), response.Headers);
            KnetikLogger.LogResponse(mGetImportJobsStartTime, "GetImportJobs", string.Format("Response received successfully:\n{0}", GetImportJobsData));

            if (GetImportJobsComplete != null)
            {
                GetImportJobsComplete(response.ResponseCode, GetImportJobsData);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetQuestionStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetQuestionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetQuestionStartTime, "GetQuestion", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetQuestionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetQuestion: " + response.Error);
            }

            GetQuestionData = (QuestionResource) KnetikClient.Deserialize(response.Content, typeof(QuestionResource), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionStartTime, "GetQuestion", string.Format("Response received successfully:\n{0}", GetQuestionData));

            if (GetQuestionComplete != null)
            {
                GetQuestionComplete(response.ResponseCode, GetQuestionData);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/{question_id}/answers/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "question_id" + "}", KnetikClient.ParameterToString(questionId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetQuestionAnswerStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetQuestionAnswerResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetQuestionAnswerStartTime, "GetQuestionAnswer", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetQuestionAnswerResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetQuestionAnswer: " + response.Error);
            }

            GetQuestionAnswerData = (AnswerResource) KnetikClient.Deserialize(response.Content, typeof(AnswerResource), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionAnswerStartTime, "GetQuestionAnswer", string.Format("Response received successfully:\n{0}", GetQuestionAnswerData));

            if (GetQuestionAnswerComplete != null)
            {
                GetQuestionAnswerComplete(response.ResponseCode, GetQuestionAnswerData);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/{question_id}/answers";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "question_id" + "}", KnetikClient.ParameterToString(questionId));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetQuestionAnswersStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetQuestionAnswersResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetQuestionAnswersStartTime, "GetQuestionAnswers", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetQuestionAnswersResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetQuestionAnswers: " + response.Error);
            }

            GetQuestionAnswersData = (List<AnswerResource>) KnetikClient.Deserialize(response.Content, typeof(List<AnswerResource>), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionAnswersStartTime, "GetQuestionAnswers", string.Format("Response received successfully:\n{0}", GetQuestionAnswersData));

            if (GetQuestionAnswersComplete != null)
            {
                GetQuestionAnswersComplete(response.ResponseCode, GetQuestionAnswersData);
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// List question deltas in ascending order of updated date The &#39;since&#39; parameter is important to avoid getting a full list of all questions. Implementors should make sure they pass the updated date of the last resource loaded, not the date of the last request, in order to avoid gaps
        /// </summary>
        /// <param name="since">Timestamp in seconds</param>
        public void GetQuestionDeltas(long? since)
        {
            
            mWebCallEvent.WebPath = "/trivia/questions/delta";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (since != null)
            {
                mWebCallEvent.QueryParams["since"] = KnetikClient.ParameterToString(since);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetQuestionDeltasStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetQuestionDeltasResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetQuestionDeltasStartTime, "GetQuestionDeltas", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetQuestionDeltasResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetQuestionDeltas: " + response.Error);
            }

            GetQuestionDeltasData = (List<DeltaResource>) KnetikClient.Deserialize(response.Content, typeof(List<DeltaResource>), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionDeltasStartTime, "GetQuestionDeltas", string.Format("Response received successfully:\n{0}", GetQuestionDeltasData));

            if (GetQuestionDeltasComplete != null)
            {
                GetQuestionDeltasComplete(response.ResponseCode, GetQuestionDeltasData);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/{id}/tags";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetQuestionTagsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetQuestionTagsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetQuestionTagsStartTime, "GetQuestionTags", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetQuestionTagsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetQuestionTags: " + response.Error);
            }

            GetQuestionTagsData = (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionTagsStartTime, "GetQuestionTags", string.Format("Response received successfully:\n{0}", GetQuestionTagsData));

            if (GetQuestionTagsComplete != null)
            {
                GetQuestionTagsComplete(response.ResponseCode, GetQuestionTagsData);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetQuestionTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetQuestionTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetQuestionTemplateStartTime, "GetQuestionTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetQuestionTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetQuestionTemplate: " + response.Error);
            }

            GetQuestionTemplateData = (QuestionTemplateResource) KnetikClient.Deserialize(response.Content, typeof(QuestionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionTemplateStartTime, "GetQuestionTemplate", string.Format("Response received successfully:\n{0}", GetQuestionTemplateData));

            if (GetQuestionTemplateComplete != null)
            {
                GetQuestionTemplateComplete(response.ResponseCode, GetQuestionTemplateData);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/templates";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (order != null)
            {
                mWebCallEvent.QueryParams["order"] = KnetikClient.ParameterToString(order);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetQuestionTemplatesStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetQuestionTemplatesResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetQuestionTemplatesStartTime, "GetQuestionTemplates", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetQuestionTemplatesResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetQuestionTemplates: " + response.Error);
            }

            GetQuestionTemplatesData = (PageResourceQuestionTemplateResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceQuestionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionTemplatesStartTime, "GetQuestionTemplates", string.Format("Response received successfully:\n{0}", GetQuestionTemplatesData));

            if (GetQuestionTemplatesComplete != null)
            {
                GetQuestionTemplatesComplete(response.ResponseCode, GetQuestionTemplatesData);
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
            
            mWebCallEvent.WebPath = "/trivia/questions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (size != null)
            {
                mWebCallEvent.QueryParams["size"] = KnetikClient.ParameterToString(size);
            }

            if (page != null)
            {
                mWebCallEvent.QueryParams["page"] = KnetikClient.ParameterToString(page);
            }

            if (order != null)
            {
                mWebCallEvent.QueryParams["order"] = KnetikClient.ParameterToString(order);
            }

            if (filterSearch != null)
            {
                mWebCallEvent.QueryParams["filter_search"] = KnetikClient.ParameterToString(filterSearch);
            }

            if (filterIdset != null)
            {
                mWebCallEvent.QueryParams["filter_idset"] = KnetikClient.ParameterToString(filterIdset);
            }

            if (filterCategory != null)
            {
                mWebCallEvent.QueryParams["filter_category"] = KnetikClient.ParameterToString(filterCategory);
            }

            if (filterTagset != null)
            {
                mWebCallEvent.QueryParams["filter_tagset"] = KnetikClient.ParameterToString(filterTagset);
            }

            if (filterTag != null)
            {
                mWebCallEvent.QueryParams["filter_tag"] = KnetikClient.ParameterToString(filterTag);
            }

            if (filterType != null)
            {
                mWebCallEvent.QueryParams["filter_type"] = KnetikClient.ParameterToString(filterType);
            }

            if (filterPublished != null)
            {
                mWebCallEvent.QueryParams["filter_published"] = KnetikClient.ParameterToString(filterPublished);
            }

            if (filterImportId != null)
            {
                mWebCallEvent.QueryParams["filter_import_id"] = KnetikClient.ParameterToString(filterImportId);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetQuestionsStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetQuestionsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetQuestionsStartTime, "GetQuestions", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetQuestionsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetQuestions: " + response.Error);
            }

            GetQuestionsData = (PageResourceQuestionResource) KnetikClient.Deserialize(response.Content, typeof(PageResourceQuestionResource), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionsStartTime, "GetQuestions", string.Format("Response received successfully:\n{0}", GetQuestionsData));

            if (GetQuestionsComplete != null)
            {
                GetQuestionsComplete(response.ResponseCode, GetQuestionsData);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/count";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterSearch != null)
            {
                mWebCallEvent.QueryParams["filter_search"] = KnetikClient.ParameterToString(filterSearch);
            }

            if (filterIdset != null)
            {
                mWebCallEvent.QueryParams["filter_idset"] = KnetikClient.ParameterToString(filterIdset);
            }

            if (filterCategory != null)
            {
                mWebCallEvent.QueryParams["filter_category"] = KnetikClient.ParameterToString(filterCategory);
            }

            if (filterTag != null)
            {
                mWebCallEvent.QueryParams["filter_tag"] = KnetikClient.ParameterToString(filterTag);
            }

            if (filterTagset != null)
            {
                mWebCallEvent.QueryParams["filter_tagset"] = KnetikClient.ParameterToString(filterTagset);
            }

            if (filterType != null)
            {
                mWebCallEvent.QueryParams["filter_type"] = KnetikClient.ParameterToString(filterType);
            }

            if (filterPublished != null)
            {
                mWebCallEvent.QueryParams["filter_published"] = KnetikClient.ParameterToString(filterPublished);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mGetQuestionsCountStartTime = DateTime.Now;
            mWebCallEvent.Context = mGetQuestionsCountResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mGetQuestionsCountStartTime, "GetQuestionsCount", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnGetQuestionsCountResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling GetQuestionsCount: " + response.Error);
            }

            GetQuestionsCountData = (long?) KnetikClient.Deserialize(response.Content, typeof(long?), response.Headers);
            KnetikLogger.LogResponse(mGetQuestionsCountStartTime, "GetQuestionsCount", string.Format("Response received successfully:\n{0}", GetQuestionsCountData));

            if (GetQuestionsCountComplete != null)
            {
                GetQuestionsCountComplete(response.ResponseCode, GetQuestionsCountData);
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
            
            mWebCallEvent.WebPath = "/trivia/import/{id}/process";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (publishNow != null)
            {
                mWebCallEvent.QueryParams["publish_now"] = KnetikClient.ParameterToString(publishNow);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mProcessImportJobStartTime = DateTime.Now;
            mWebCallEvent.Context = mProcessImportJobResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.POST;

            KnetikLogger.LogRequest(mProcessImportJobStartTime, "ProcessImportJob", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnProcessImportJobResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling ProcessImportJob: " + response.Error);
            }

            ProcessImportJobData = (ImportJobResource) KnetikClient.Deserialize(response.Content, typeof(ImportJobResource), response.Headers);
            KnetikLogger.LogResponse(mProcessImportJobStartTime, "ProcessImportJob", string.Format("Response received successfully:\n{0}", ProcessImportJobData));

            if (ProcessImportJobComplete != null)
            {
                ProcessImportJobComplete(response.ResponseCode, ProcessImportJobData);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/{id}/tags/{tag}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "tag" + "}", KnetikClient.ParameterToString(tag));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mRemoveQuestionTagStartTime = DateTime.Now;
            mWebCallEvent.Context = mRemoveQuestionTagResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mRemoveQuestionTagStartTime, "RemoveQuestionTag", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnRemoveQuestionTagResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling RemoveQuestionTag: " + response.Error);
            }

            KnetikLogger.LogResponse(mRemoveQuestionTagStartTime, "RemoveQuestionTag", "Response received successfully.");
            if (RemoveQuestionTagComplete != null)
            {
                RemoveQuestionTagComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/tags/{tag}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "tag" + "}", KnetikClient.ParameterToString(tag));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterSearch != null)
            {
                mWebCallEvent.QueryParams["filter_search"] = KnetikClient.ParameterToString(filterSearch);
            }

            if (filterIdset != null)
            {
                mWebCallEvent.QueryParams["filter_idset"] = KnetikClient.ParameterToString(filterIdset);
            }

            if (filterCategory != null)
            {
                mWebCallEvent.QueryParams["filter_category"] = KnetikClient.ParameterToString(filterCategory);
            }

            if (filterTag != null)
            {
                mWebCallEvent.QueryParams["filter_tag"] = KnetikClient.ParameterToString(filterTag);
            }

            if (filterTagset != null)
            {
                mWebCallEvent.QueryParams["filter_tagset"] = KnetikClient.ParameterToString(filterTagset);
            }

            if (filterType != null)
            {
                mWebCallEvent.QueryParams["filter_type"] = KnetikClient.ParameterToString(filterType);
            }

            if (filterPublished != null)
            {
                mWebCallEvent.QueryParams["filter_published"] = KnetikClient.ParameterToString(filterPublished);
            }

            if (filterImportId != null)
            {
                mWebCallEvent.QueryParams["filter_import_id"] = KnetikClient.ParameterToString(filterImportId);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mRemoveTagToQuestionsBatchStartTime = DateTime.Now;
            mWebCallEvent.Context = mRemoveTagToQuestionsBatchResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.DELETE;

            KnetikLogger.LogRequest(mRemoveTagToQuestionsBatchStartTime, "RemoveTagToQuestionsBatch", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnRemoveTagToQuestionsBatchResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling RemoveTagToQuestionsBatch: " + response.Error);
            }

            RemoveTagToQuestionsBatchData = (int?) KnetikClient.Deserialize(response.Content, typeof(int?), response.Headers);
            KnetikLogger.LogResponse(mRemoveTagToQuestionsBatchStartTime, "RemoveTagToQuestionsBatch", string.Format("Response received successfully:\n{0}", RemoveTagToQuestionsBatchData));

            if (RemoveTagToQuestionsBatchComplete != null)
            {
                RemoveTagToQuestionsBatchComplete(response.ResponseCode, RemoveTagToQuestionsBatchData);
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
            
            mWebCallEvent.WebPath = "/trivia/tags";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterSearch != null)
            {
                mWebCallEvent.QueryParams["filter_search"] = KnetikClient.ParameterToString(filterSearch);
            }

            if (filterCategory != null)
            {
                mWebCallEvent.QueryParams["filter_category"] = KnetikClient.ParameterToString(filterCategory);
            }

            if (filterImportId != null)
            {
                mWebCallEvent.QueryParams["filter_import_id"] = KnetikClient.ParameterToString(filterImportId);
            }

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mSearchQuestionTagsStartTime = DateTime.Now;
            mWebCallEvent.Context = mSearchQuestionTagsResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.GET;

            KnetikLogger.LogRequest(mSearchQuestionTagsStartTime, "SearchQuestionTags", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnSearchQuestionTagsResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling SearchQuestionTags: " + response.Error);
            }

            SearchQuestionTagsData = (List<string>) KnetikClient.Deserialize(response.Content, typeof(List<string>), response.Headers);
            KnetikLogger.LogResponse(mSearchQuestionTagsStartTime, "SearchQuestionTags", string.Format("Response received successfully:\n{0}", SearchQuestionTagsData));

            if (SearchQuestionTagsComplete != null)
            {
                SearchQuestionTagsComplete(response.ResponseCode, SearchQuestionTagsData);
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
            
            mWebCallEvent.WebPath = "/trivia/import/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(request); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateImportJobStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateImportJobResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateImportJobStartTime, "UpdateImportJob", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateImportJobResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateImportJob: " + response.Error);
            }

            UpdateImportJobData = (ImportJobResource) KnetikClient.Deserialize(response.Content, typeof(ImportJobResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateImportJobStartTime, "UpdateImportJob", string.Format("Response received successfully:\n{0}", UpdateImportJobData));

            if (UpdateImportJobComplete != null)
            {
                UpdateImportJobComplete(response.ResponseCode, UpdateImportJobData);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(question); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateQuestionStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateQuestionResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateQuestionStartTime, "UpdateQuestion", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateQuestionResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateQuestion: " + response.Error);
            }

            UpdateQuestionData = (QuestionResource) KnetikClient.Deserialize(response.Content, typeof(QuestionResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateQuestionStartTime, "UpdateQuestion", string.Format("Response received successfully:\n{0}", UpdateQuestionData));

            if (UpdateQuestionComplete != null)
            {
                UpdateQuestionComplete(response.ResponseCode, UpdateQuestionData);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/{question_id}/answers/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "question_id" + "}", KnetikClient.ParameterToString(questionId));
mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(answer); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateQuestionAnswerStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateQuestionAnswerResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateQuestionAnswerStartTime, "UpdateQuestionAnswer", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateQuestionAnswerResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateQuestionAnswer: " + response.Error);
            }

            KnetikLogger.LogResponse(mUpdateQuestionAnswerStartTime, "UpdateQuestionAnswer", "Response received successfully.");
            if (UpdateQuestionAnswerComplete != null)
            {
                UpdateQuestionAnswerComplete(response.ResponseCode);
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
            
            mWebCallEvent.WebPath = "/trivia/questions/templates/{id}";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{" + "id" + "}", KnetikClient.ParameterToString(id));

            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            mWebCallEvent.PostBody = KnetikClient.Serialize(questionTemplateResource); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateQuestionTemplateStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateQuestionTemplateResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateQuestionTemplateStartTime, "UpdateQuestionTemplate", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateQuestionTemplateResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateQuestionTemplate: " + response.Error);
            }

            UpdateQuestionTemplateData = (QuestionTemplateResource) KnetikClient.Deserialize(response.Content, typeof(QuestionTemplateResource), response.Headers);
            KnetikLogger.LogResponse(mUpdateQuestionTemplateStartTime, "UpdateQuestionTemplate", string.Format("Response received successfully:\n{0}", UpdateQuestionTemplateData));

            if (UpdateQuestionTemplateComplete != null)
            {
                UpdateQuestionTemplateComplete(response.ResponseCode, UpdateQuestionTemplateData);
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
            
            mWebCallEvent.WebPath = "/trivia/questions";
            if (!string.IsNullOrEmpty(mWebCallEvent.WebPath))
            {
                mWebCallEvent.WebPath = mWebCallEvent.WebPath.Replace("{format}", "json");
            }
            
            mWebCallEvent.HeaderParams.Clear();
            mWebCallEvent.QueryParams.Clear();
            mWebCallEvent.AuthSettings.Clear();
            mWebCallEvent.PostBody = null;

            if (filterSearch != null)
            {
                mWebCallEvent.QueryParams["filter_search"] = KnetikClient.ParameterToString(filterSearch);
            }

            if (filterIdset != null)
            {
                mWebCallEvent.QueryParams["filter_idset"] = KnetikClient.ParameterToString(filterIdset);
            }

            if (filterCategory != null)
            {
                mWebCallEvent.QueryParams["filter_category"] = KnetikClient.ParameterToString(filterCategory);
            }

            if (filterTagset != null)
            {
                mWebCallEvent.QueryParams["filter_tagset"] = KnetikClient.ParameterToString(filterTagset);
            }

            if (filterType != null)
            {
                mWebCallEvent.QueryParams["filter_type"] = KnetikClient.ParameterToString(filterType);
            }

            if (filterPublished != null)
            {
                mWebCallEvent.QueryParams["filter_published"] = KnetikClient.ParameterToString(filterPublished);
            }

            if (filterImportId != null)
            {
                mWebCallEvent.QueryParams["filter_import_id"] = KnetikClient.ParameterToString(filterImportId);
            }

            mWebCallEvent.PostBody = KnetikClient.Serialize(question); // http body (model) parameter
 
            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_client_credentials_grant");

            // authentication settings
            mWebCallEvent.AuthSettings.Add("oauth2_password_grant");

            // make the HTTP request
            mUpdateQuestionsInBulkStartTime = DateTime.Now;
            mWebCallEvent.Context = mUpdateQuestionsInBulkResponseContext;
            mWebCallEvent.RequestType = KnetikRequestType.PUT;

            KnetikLogger.LogRequest(mUpdateQuestionsInBulkStartTime, "UpdateQuestionsInBulk", "Sending server request...");
            KnetikGlobalEventSystem.Publish(mWebCallEvent);
        }

        private void OnUpdateQuestionsInBulkResponse(KnetikRestResponse response)
        {
            if (!string.IsNullOrEmpty(response.Error))
            {
                throw new KnetikException("Error calling UpdateQuestionsInBulk: " + response.Error);
            }

            UpdateQuestionsInBulkData = (int?) KnetikClient.Deserialize(response.Content, typeof(int?), response.Headers);
            KnetikLogger.LogResponse(mUpdateQuestionsInBulkStartTime, "UpdateQuestionsInBulk", string.Format("Response received successfully:\n{0}", UpdateQuestionsInBulkData));

            if (UpdateQuestionsInBulkComplete != null)
            {
                UpdateQuestionsInBulkComplete(response.ResponseCode, UpdateQuestionsInBulkData);
            }
        }

    }
}
