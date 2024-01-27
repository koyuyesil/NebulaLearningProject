select count(*) from Exams
select count(*) from Exams where ExamName like '%Math%'


SELECT Roles.Name
FROM Users
JOIN UserRoles ON Users.ID = UserRoles.UserID
JOIN Roles ON UserRoles.RoleID = Roles.ID
WHERE Users.ID = 2;

SELECT r.Name AS RoleName
FROM UserRoles ur
JOIN Roles r ON ur.RoleId = r.Id
WHERE ur.UserId = 2;