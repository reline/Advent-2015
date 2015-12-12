<?php
	$input = fopen("input.txt", "r") or die ("Unable to open file!");

	$lines = array();
	$codeChar = 0;
	$memChar = 0;

	while(!feof($input)) {
		array_push($lines, fgets($input));
	}

	for ($i=0; $i < count($lines); $i++) {

		$codeCharactersOnThisLine = 0;
		$memoryCharactersOnThisLine = 0;

		for ($j=0; $j < strlen($lines[$i]); $j++) { 

			$codeCharactersOnThisLine++;

			$char = substr($lines[$i], $j, 1);
			$nextChar = substr($lines[$i], $j + 1, 1);

			// if the char is a double quotation mark
			if ($char == "\"") {
				
				// if it is the first or last character in the line
				if ($j == 0 || $j == strlen($lines[$i]) - 1) {
					$memoryCharactersOnThisLine += 3;
				} else {
					$memoryCharactersOnThisLine += 2;
				}
			} elseif ($char == "\\") {
				$memoryCharactersOnThisLine += 2;
			} else {
				$memoryCharactersOnThisLine++;
			}
		}

		$codeChar += $codeCharactersOnThisLine - 1;
		$memChar += $memoryCharactersOnThisLine;
	}

	echo "<br>";
	echo "Code characters: " . $codeChar . "<br>";
	echo "Memory characters: " . $memChar . "<br>";
	echo "Answer: " . ($memChar - $codeChar) . "<br>";

	fclose($input);
?>