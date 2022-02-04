//Alessio Modonesi 4F
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/wait.h>

int main()
{
    int P0_P2[2], P1_P2[2];
    pipe(P0_P2);
    pipe(P1_P2);

    int PID1 = fork();
    if (PID1 < 0)
    {
        printf("Errore nella generazione del figlio: %d\n", getpid());
        exit(1);
    }
    else if (PID1 == 0) 
    {
        close(1); 
        dup(P1_P2[1]); 
        close(P1_P2[1]);
        close(P1_P2[0]); 

        execl("/bin/cat", "cat", "file.txt", (char* )0); 
        exit(0);
    }
    else
    {
        int PID2 = fork();
        if (PID2 < 0)
        {
            printf("Errore nella generazione del figlio: %d\n", getpid());
            exit(1);
        }
        else if (PID2 == 0)
        {
            close(0); 
            dup(P1_P2[0]); 
            close(P1_P2[0]); 
            close(P1_P2[1]);

            close(1); 
            dup(P0_P2[1]); 
            close(P0_P2[1]);
            close(P0_P2[0]); 

            execl("/bin/wc", "wc", (char* )0);
            exit(0);
        }
        else
        {
            close(0); 
            dup(P0_P2[0]); 
            close(P0_P2[0]); 
            close(P0_P2[1]);

            FILE *file;
            int on = open("output.txt", O_WRONLY);

            close(P1_P2[0]); 
            close(P1_P2[1]);
            close(P0_P2[0]); 
            close(P0_P2[1]);
        }    
    }
    return 0;
}