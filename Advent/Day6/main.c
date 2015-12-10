#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <inttypes.h>

void flipSwitch(char* inst, int array[1000][1000], int x1, int y1, int x2, int y2);

int main(void)
{
	int lights[1000][1000] = {0};
	memset(lights, 0, sizeof(lights));

	for (int i = 0; i < 1000; i++) {
		for (int j = 0; j < 1000; j++) {
			//printf("%d,%d\n", i, j);
			lights[i][j] = 0;
		}
	}

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
   			flipSwitch("toggle", lights, strtoumax(words[1], NULL, 10), strtoumax(words[2], NULL, 10), strtoumax(words[4], NULL, 10), strtoumax(words[5], NULL, 10));
   		}
   		else if (strcmp(words[1], "on") == 0) {
   			flipSwitch("on", lights, strtoumax(words[2], NULL, 10), strtoumax(words[3], NULL, 10), strtoumax(words[5], NULL, 10), strtoumax(words[6], NULL, 10));
		}
   		else if (strcmp(words[1], "off") == 0) {
   			flipSwitch("off", lights, strtoumax(words[2], NULL, 10), strtoumax(words[3], NULL, 10), strtoumax(words[5], NULL, 10), strtoumax(words[6], NULL, 10));
   		}
   }

   int lightCount = 0;
   // count lights that are on
   for (int i = 0; i < 1000; i++) {
		for (int j = 0; j < 1000; j++) {
			lightCount += lights[i][j];
		}
	}
	printf("%d\n", lightCount);

   fclose(fp);
   if (line)
       free(line);
   exit(EXIT_SUCCESS);
}

void flipSwitch(char* inst, int array[1000][1000], int x1, int y1, int x2, int y2) {
	for (int i = x1; i <= x2; i++) {
		for (int j = y1; j <= y2; j++) {
			
			if (inst == "toggle") {
				// array[i][j] = !array[i][j]; // part 1
				array[i][j] += 2;
			} else if (inst == "on") {
				// array[i][j] = 1; // part 1
				array[i][j]++;
			} else if (inst == "off") {
				// array[i][j] = 0; // part 1
				if (array[i][j] > 0) array[i][j]--;
			}
		}
	}
}