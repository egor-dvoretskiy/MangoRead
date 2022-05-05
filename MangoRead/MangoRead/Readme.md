# Markdown File

### TODO list

+ Make all views for IManuscriptRepository.cs
+ Make an authorize system through Identity
+ Make user and Admin models
- Add approval manuscript system (AMS): user fills a manuscript create form, then this form waiting for approval from admin. firstly goes to ManusciptDraft db -> secondly, ManuscriptApproved db
- Make layout a little bit beauty than now
+ Mechanism add to genres
- Mechanism add to Content (seq: create -> upload ??) >> first. add empty manuscript; second. get to details; third. add files to content.
+ add to account 'manuscript managment' field with approved and requested manuscripts.
+ get rid of 'create new' from index and move it to manuscript management page with name 'add new manuscript request'.
+ Add authorize attribute to manuscript actions.
+ Make manuscript CRUD according to roles.
+ Change @Html.ListBoxFor to listbox
+ details -> genreString
+ make account manage menu
+ rework login/signup from controllers to razorpages
+ make create TitleImage as IFormFile
+ add title image to details and edit
- add restriction to change SuperAdmin roles by everybody else
- add different manuscriptmanagement pages for admins and basic users
- add enum for approve status



### Migration Commands

add-migration RenameIdentityTableNamesMigration -Context AccountDbContext -Project MangoRead.DAL
update-database -Context AccountDbContext -Project MangoRead.DAL