//Alessio Modonesi 4F
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <unistd.h>
#include <sys/wait.h>

#define MAX 10

int main(int argc, char *argv[])
{
    if (argc == 2)
    {
        int totale = 0;
        char str[MAX];
        int piped[2];
        pipe(piped);

        while (1)
        {
            printf("Inserisci la parola che vuoi cercare: ");
            scanf("%s", str);
            if (strcmp(str, "fine") != 0)
            {
                int PID = fork();
                if (PID == 0)
                {
                    close(1);
                    dup(piped[1]);
                    close(piped[1]);
                    close(piped[0]);

                    execl("/bin/grep", "grep", "-c", str, argv[1], NULL);
                    exit(0);
                }
                else
                {
                    wait(&PID);
                    char cont;
                    read(piped[0], &cont, 1024);
                    printf("'%s' è stata individuata %d volte\n", str, atoi(&cont));
                    totale += atoi(&cont);
                }
            }
            else 
                break;  
        }
        printf("Ho trovato %d parole\n", totale);
    }
    else
        printf("Argomenti errati\n");
    return 0;
}