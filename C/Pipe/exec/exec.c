#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/wait.h>

int main()
{
    int status;
    char fileName[] = "file.txt";
    int fd[2];
    pipe(fd);

    int PID1 = fork();
    if (PID1 == 0) 
    {
        close(1);
        dup(fd[1]);
        close(fd[1]);

        execl("/bin/sh", "cat", "file.txt", NULL);
        exit(0);
    }
    else
    {
        int PID2 = fork();
        if (PID2 == 0)
        {
            close(0);
            dup(fd[0]);
            close(fd[0]);

            execl("/bin/sh", "wc", NULL);
            exit(0);
        }
        else
            wait(&status);
            printf("Processo terminato\n");
    }
    return 0;
}