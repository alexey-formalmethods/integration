using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.gitlab.reporting.Models
{
    public class IssueUser
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty(PropertyName = "web_url")]
        public string WebUrl { get; set; }
    }
    public class ClosedByIssueUser : IssueUser { }

    public class AuthorIssueUser : IssueUser { }

    public class AssigneeIssueUser : IssueUser { }

    public class IssueTimeStats
    {
        [JsonProperty(PropertyName = "time_estimate")]
        public int TimeEstimate { get; set; }

        [JsonProperty(PropertyName = "total_time_spent")]
        public int TotalTimeSpent { get; set; }

        [JsonProperty(PropertyName = "human_time_estimate")]
        public object HumanTimeEstimate { get; set; }

        [JsonProperty(PropertyName = "human_total_time_spent")]
        public object HumanTotalTimeSpent { get; set; }
    }

    public class IssuesRestResponse
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "iid")]
        public int Iid { get; set; }

        [JsonProperty(PropertyName = "project_id")]
        public int ProjectId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "closed_at")]
        public DateTime? ClosedAt { get; set; }

        [JsonProperty(PropertyName = "closed_by")]
        public ClosedByIssueUser closed_by { get; set; }

        [JsonProperty(PropertyName = "labels")]
        public List<object> Labels { get; set; }

        [JsonProperty(PropertyName = "milestone")]
        public object Milestone { get; set; }

        [JsonProperty(PropertyName = "assignees")]
        public List<object> Assignees { get; set; }

        [JsonProperty(PropertyName = "author")]
        public AuthorIssueUser author { get; set; }

        [JsonProperty(PropertyName = "assignee")]
        public AssigneeIssueUser Assignee { get; set; }

        [JsonProperty(PropertyName = "user_notes_count")]
        public int UserNotesCount { get; set; }

        [JsonProperty(PropertyName = "merge_requests_count")]
        public int MergeRequestsCount { get; set; }

        [JsonProperty(PropertyName = "upvotes")]
        public int Upvotes { get; set; }

        [JsonProperty(PropertyName = "downvotes")]
        public int Downvotes { get; set; }

        [JsonProperty(PropertyName = "due_date")]
        public string DueDate { get; set; }

        [JsonProperty(PropertyName = "confidential")]
        public bool Confidential { get; set; }

        [JsonProperty(PropertyName = "discussion_locked")]
        public object DiscussionLocked { get; set; }

        [JsonProperty(PropertyName = "web_url")]
        public string WebUrl { get; set; }

        [JsonProperty(PropertyName = "time_stats")]
        public IssueTimeStats TimeStats { get; set; }
    }
}
