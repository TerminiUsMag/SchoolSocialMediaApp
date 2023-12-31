# School Social Media App Project.

This is a school social media web application I'm developing for SoftUni's "ASP.NET Advanced" course.

[Link to the course page](https://softuni.bg/trainings/4107/asp-net-advanced-june-2023).
---------------------------------------------------------------------------------------------------------------------
Requirements for the project are added in folder "Project Requirements".

First Run:  
On the first run the application will seed: 
<ul>
  <li>Admin User: Can Manage the whole application (Delete users, manage schools, send invitations, delete and edit posts, delete comments, change school pictures and more).</li>
  <li>Principal User: Has demo school and a post in the school. Can Manage the whole school.(Send invitations, remove users from school, manage posts and comments).</li>
  <li>Student User: Has invitation from the principal to join the demo school as a student, commented and liked the Principal's post. Can post and comment in the school which he is part of, can quit the school and can receive invitations from principals and admins to join schools as a concreate role.</li>
  <li>Parent User: Can be added to the school as parent.  </li>
  <li>Teacher User: Can be added to the school as teacher. </li>
</ul>

Seeded users login information:
<ul>
  <li>email: admin@admins.com | password: "None123"</li>
  <li>email: principal@principals.com | password: "None123"</li>
  <li>email: teacher@teachers.com | password: "None123"</li>
  <li>email: parent@parents.com | password: "None123"</li>
  <li>email: student@students.com | password: "None123"</li>
</ul>
 
Main Functionalities:
<ol>
  <li>Not registered users have access to registered schools page.</li>
  <li>Registered schools page has seach by name functionality.</li>
  <li>Users Login and Register.</li>
  <li>After registration you can register your school (You become the "principal" of the school).</li>
  <li>When registering your school you have the option to use your current location for the school's location field.</li>
  <li>The Principal can send invitations to Non-Principal users to be teachers, parents or students in his school.</li>
  <li>Invited Users receive the principal's invitation and can choose to accept or decline the invitation.</li>
  <li>At any time the user can quit the school he is part of.</li>
  <li>As a part of school you have access to all posts related to the school you are part of.</li>
  <li>Pagination for school's posts page.</li>
  <li>As a part of school you can like and comment each post related to your school.</li>
  <li>If you are the creator of a post you can edit and delete it.</li>
  <li>If you are the principal of a school you can edit and delete every post related to the school.</li>
  <li>The admin can edit or delete every post related to every school and can delete whole schools and users.</li>
  <li>You can edit your profile, change your profile picture.</li>
  <li>If you are a principal you can edit your school and change it's profile picture.</li>
  <li>Admin Panel.</li>
  <li>As admin you can do everything the principal can for every registered school.(Excluding: Post Creation).</li>
  <li>The admin can delete users.</li>
</ol>
<h1>Project Overview</h1>

<h2>Home Page: </h2>

![Screenshot (53)](https://github.com/TerminiUsMag/SchoolSocialMediaApp/assets/59938500/223690da-c999-4f6a-aa16-f023ee6ea821)


<h2>Schools Page: </h2>

![image](https://github.com/TerminiUsMag/SchoolSocialMediaApp/assets/59938500/c66e5398-5767-49a0-801c-60b32de0558c)

<h2>Manage School Page: </h2>

![Screenshot (55)](https://github.com/TerminiUsMag/SchoolSocialMediaApp/assets/59938500/9ef0cc24-881e-4c37-a412-e8489cb024ba)

<h2>Manage Account Page: </h2>

![Screenshot (56)](https://github.com/TerminiUsMag/SchoolSocialMediaApp/assets/59938500/c021b8e5-8031-43cc-89d9-d4d1a78beb05)

<h2>Posts Page (from principal's view): </h2>

![Screenshot (57)](https://github.com/TerminiUsMag/SchoolSocialMediaApp/assets/59938500/66b6a8d3-db18-49e3-8b40-dae8861be61c)

<h2>Pending Invitations Page: </h2>

![Screenshot (58)](https://github.com/TerminiUsMag/SchoolSocialMediaApp/assets/59938500/0d28be21-c60b-4ab8-bd4a-a78c6a84406a)

<h2>Posts Page (from a student's view): </h2>

![Screenshot (61)](https://github.com/TerminiUsMag/SchoolSocialMediaApp/assets/59938500/8c2e9ca8-13e5-42d9-811e-f277c87aaac6)


<h2>Admin Panel: </h2>

![image](https://github.com/TerminiUsMag/SchoolSocialMediaApp/assets/59938500/e434447c-b2ae-4ed8-95b4-3864a0eb24eb)



