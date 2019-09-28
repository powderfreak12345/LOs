Author:    Jonathan Beutler
Partner:   None
Date:      September 4, 2019
Repo:	   https://github.com/powderfreak12345/LOs
Course:    CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Jonathan Beutler - This work may not be copied for use in Academic Coursework.

Comments to Evaluators:

Repo:	   https://github.com/powderfreak12345/LOs

-----------------Authentication and Authoization:-----------------------
Authentication and authorization were an interesting challenge to implement.  For authorization,
I didn't realize that my NetCore app was targeting 2.1, not 2.2.  After I figured out what
the problem was on my own, I noticed the Piazza post explaining it all.  Hooray.  Because
of the dealy, I wasn't able to spend a ton of time on A&A stuff, but I did learn a few things.

First of all, it is generally much easier to create separate controllers for each role type.
Initially, I wanted to keep the directories and classes for my project simple.  As I added
more and more unique features to each controller, the controllers themselves became very 
difficult to manage.  Splitting them up into separate entities made debugging and creating
custom pages a lot easier.  I did still use a single shared _layout.cshtml file.  In the top,
I parsed out the roles for the user and included them next to their user name.  The parsing took
up a good chunk of space in that file, so I'm glad I only had to do it there and not in every
view.  

The administrators role view/change was an intersting challenge to implement.  Because the 
IdentityRole didn't have an easily accessible model to scaffold off of, I created an empty 
controller that didn't use any model.  From there, I created the ability to construct a single
Razor page.  Still though, the Razor Page didn't have a model object associated with it.  In the 
Razor page, I parsed out all of the users and their roles to display.  If there is some other, 
better way to do this, I would really appreciate a demonstration in class.

---------------Above and Beyond------------------------------------------
For the Department Chair view of the courses, I needed a way for them to easily see
how much "progress" had been made in a course.  To measure progress, I came up with 
a system whereby the % progress is a function of how many Learning Outcomes have
Evaluation Metrics attached to them.  Within the razor code, I iterate through the
Learning Outcomes and determine which ones have Evaluation Metrics.  Then using some 
simple math, I determine the % progress and display it on a status bar.

---------------Improvements----------------------------------------------
Since PS3 was a total flop (10/100 points), I had to create a lot of that functionality
in PS4.  In viewing the progress from PS1->PS2->PS3->PS4, there will be a noticeable
improvement in this latest release.

---------------Other notes----------------------------------------------
For the email authentication, I encountered the same problem described in this
Piazza post titled "VPN Issues ("Authentication Required")".  Basically, unless I explicity
type my UofU credentials into the source code (A VERY BAD IDEA), I cannot send any
authentication emails.  At the time of submission, the best answer from the professor
was that no SMTP credential are required on the U's server.  This isn't true.  If I remove
my credentials, it refuses to send.  So for now, I've set the credentials to:
new NetworkCredential() {UserName="NA", Password="NA"};  It will fail during testing
unless credentials are provided.  I wish there was a better way to handle this, but again,
no solution has been provided.



TO ASK DURING TA HOURS:

Consulted Peers:
None.

References:

1. Block U Logo - https://www.uredzone.com/storeimages/182-1465319-1.jpg
2. User Image - https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/User_icon_2.svg/220px-User_icon_2.svg.png
3. Course Descriptions - https://catalog.utah.edu/#/courses
4. Contosa University Example - https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-2.2