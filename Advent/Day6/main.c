#define _GNU_SOURCE
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <inttypes.h>

#include "main.h"

int main(void)
{
	int lights[1000][1000];// = {0};
	//memset(lights, 0, sizeof(lights));
	//printf("%d\n", lights[0][0]);

   	FILE * fp;
   	char * line = NULL;
   	size_t len = 0;
   	ssize_t read;

   	fp = fopen("input.txt", "r");
   	while ((read = getline(&line, &len, fp)) != -1) {
   		char *words[8];

   		char * pch;
   		pch = strtok(line, " ,");
   		int wordNum = 0;
   		while (pch != NULL) {
   			words[wordNum] = pch;
   			pch = strtok(NULL, " ,");
   			wordNum++;
   		}

   		if (strcmp(words[0], "toggle") == 0) {
   			// toggle words[1] words[2] through words[4] words[5]
   			fillArray(*lights, strtoumax(words[1], NULL, 10), strtoumax(words[2], NULL, 10), strtoumax(words[4], NULL, 10), strtoumax(words[5], NULL, 10));
   		}
   		else if (strcmp(words[1], "on") == 0) {
   			// turn on words[2] words[3] through words[5] words[6]
		}
   		else if (strcmp(words[1], "off") == 0) {
   			// turn off words[2] words[3] through words[5] words[6]
   		}
   }

   fclose(fp);
   if (line)
       free(line);
   exit(EXIT_SUCCESS);
}

void fillArray(int* array, int x1, int y1, int x2, int y2) {
	printf("%s\n", "fillArray");
}

struct Pair {
  int first;
  int second;
};