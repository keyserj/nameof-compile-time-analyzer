# nameof Compile Time Analyzer

## Purpose
To identify how much of an effect that the use of the keyword "nameof" plays on compile times compared to other ways of outputting strings (currently compared to just string literals)

## How to use
Unfortunately there's no interface implemented yet and the inputs are all hardcoded into the project, so if you want to modify that number of duplicate files created, number of lines per file, number of times to build each project, or the strings being duplicated, you've actually got to open TestBigProject.csproj and change the proper constants/variables in Program.cs. In code, the parameters are named:

*	NUM_DUPLICATE_FILES
*	NUM_LINES_PER_FILE
*	NUM_TIMES_TO_BUILD_PROJECTS

Once you've got your parameters set up, build, then run without debugging or place a breakpoint and run with debugging.

## How it works
A number of files equal to NUM_DUPLICATE_FILES are created in the root/TestBigNameOf/DuplicatedNameOfFiles and root/TestBigLiteral/DuplicatedLiteralFiles directories, then added as inclusions to the TestBigNameOf and TestBigLiteral csproj files. The csproj files are then built using MSBuild NUM_TIMES_TO_BUILD_PROJECTS times, and the time per build is output, along with the average build times when all builds are complete.

The following string.Format is used as a base for each file that'll be duplicated

```csharp
@"namespace {0}
{{
    class Program{1}
    {{
        private void Test()
        {{
            string s;
{2}        }}
    }}
}}"
```

The Format parameters are defined as follows:

*	{0} : path to the folder that will hold the duplicate files for the project
*	{1} : file # (between 0 and NUM_DUPLICATE_FILES - 1, inclusive)
*	{2} : file body, which is made up entirely of NUM_LINES_PER_FILE lines created using formatNameOf and formatLiteral, e.g. `s = nameof(Program3);` where Program3 is a random class reference from one of the created/to-be-created files

## Example output
![Alt text](https://i.imgur.com/y064oWD.png)