Author:    Jonathan Beutler
Partner:   None
Date:      September 4, 2019
Repo:	   https://github.com/powderfreak12345/LOs
Course:    CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Jonathan Beutler - This work may not be copied for use in Academic Coursework.

Comments to Evaluators:

Bootstrap choice: Use progress bars
	In PS1, the way an instructor could summarize his/her progress in a course was through a drop down menu with options
	of 'Not Started', 'In Progress', and 'Completed'.  For PS2, I decided to redo this progress system using student work
	examples to demonstrate how far along the progress is.  The instructor is required to upload five examples of student
	work per evaulation metric, and a progress bar updates as more are added.

Bootstrap choice: Use tables
	In PS2, I upgraded the page structures used to contain assignment definitions and student work examples.  Previously, 
	the file download links for these was more or less floating in space.  With the addition of Bootstrap, I was able to use
	their table components to contain these files.  For the student work examples, having a table with 5 empty rows is a good
	way to emphasize to the user that 5 examples are required.

Bootstrap choice: Use bootstrap grid
	On the right hand side of the navigation bar, there is a dropdown for the user.  Under this dropdown are the 'User Preferences'
	and 'Logout' buttons.  The unexpanded dropdown item contains the user's name, role, and a profile image.  In order to fit all
	of these components into the single button, I used the bootstrap grid to organize them in a visually pleasing way.

UI Improvement: Use progress bars as a more descriptive means for an instructor to demonstrate progress (see above).
UI Improvement: Use tables to hold student assignment definitions and student work examples (see above).
UI Improvement: Replace the html for my homegrown navigation bar with bootstrap navigation componenets.  It also allowed me to keep
					all of my navigation html in one _Layout.cshtml instead of repeating the same html at the top of each page file.

Consulted Peers:
None.  I'm still in Alaska and don't know anybody in the class.

References:

1. Block U Logo - https://www.uredzone.com/storeimages/182-1465319-1.jpg
2. User Image - https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/User_icon_2.svg/220px-User_icon_2.svg.png