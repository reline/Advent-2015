<?php
	$input = fopen("input.txt", "r") or die ("Unable to open file!");

	$lines = array();
	$codeChar = 0;
	$memChar = 0;

	while(!feof($input)) {
		array_push($lines, fgets($input));
	}

	for ($i=0; $i < count($lines); $i++) {
		// count code characters
		$codeChar += strlen($lines[$i]) - 1;
		$memoryCharactersOnThisLine = 0;

		// count memory characters
		for ($j=0; $j < strlen($lines[$i]); $j++) { 

			$char = substr($lines[$i], $j, 1);

			// if the char is a backslash
			if ($char == "\\") {

				$nextChar = substr($lines[$i], $j + 1, 1);

				// if the next character is x followed by any two character combination of 0-9 & A-F represents a single character
				if ($nextChar == "x") {
					$validChars = array('0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f');
					$hex1 = substr($lines[$i], $j + 2, 1);
					$hex2 = substr($lines[$i], $j + 3, 1);
					if (in_array($hex1, $validChars) && in_array($hex2, $validChars)) {
						$j += 3;
					}
				}				

				// if the next character is a backslash or a double quotation mark
				elseif ($nextChar == "\\" || $nextChar == "\"") {
					$j++;
				}

				$memoryCharactersOnThisLine++;

			} elseif ($char != "\"") {
				// if the char is not a double quotation mark
				$memoryCharactersOnThisLine++;
			}
		}

		$memChar += $memoryCharactersOnThisLine - 1;
		
	}

	echo "<br>";
	echo "Code characters: " . $codeChar . "<br>";
	echo "Memory characters: " . $memChar . "<br>";
	echo "Answer: " . ($codeChar - $memChar) . "<br>";

	fclose($input);
?>