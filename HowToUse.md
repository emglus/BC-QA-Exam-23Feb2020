# How to USE BCQAExam.sln

BCQAExam.sln is VS 2019 solution file wich utilises NuGet packages. 
Out of the box, the github repository doesn't contain packages folder. 
To successfully build and run the solution, please do the following:

1. Open the solution file using VS 2019
2. In Solution explorer, right click on solution and execute Restore NuGet Packages.
   It may take a bit of time before the option becomes enabled.
3. Close Visual Studio.
4. Open the solution file using VS 2019, allowing the packages to load.
5. Re-build solution
6. Run Test>Text Explorer
7. There are 2 tests. Run them. They should both PASS.

If you want to manually login as the last registered user, the randomly generated email address used for registration
is logged in the Output/Test window.


