School Managment System

#How To Start
 >>when you Run The application the DB migration is executed 
 >>you Can Authenticatue (The Password Check Always return False so i create the Toket/[UserNAme] to get token until solve it)

    UserName --> amany her Role is Admin for schoolid 1		
	UserName  --> ahmed is For Normal User for Schoolid 1
	UserName  --> amal is For Admin User for schoolid 2
	UserName  --> heba is For Normal User for schoolid 2
	
2	there Are two 

>>End Points for Auth 
>>> [Get]  
https://localhost:44328/api/Auth/token/userName?userName=amany 
https://localhost:44328/api/Auth/token/userName?userName=amany
https://localhost:44328/api/Auth/token/userName?userName=amal
https://localhost:44328/api/Auth/token/userName?userName=heba
	its get the token to test the authorization For Classes End point
	
##End points Fo Classes
### https://localhost:44328/api/Classes [Get]

to get All Classes for his school only

>> https://localhost:44328/api/AddClass [Post]
{
  "className": "S1-C4",
  "floor": 1
}

>> https://localhost:44328/api/DeleteClass/1 [Delete]
 Param --> ClassID
>> https://localhost:44328/api/EditClass/1?name=S1-C2&floor=4 [Put] 
param --> classID,className,floor