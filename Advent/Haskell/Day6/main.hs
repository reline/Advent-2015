import Control.Monad

main = do
	content <- readFile "input.txt"
	-- 'lines' returns an array of strings, each line of the file
	let text = lines content

	-- 'forM_' performs an operation on every line in text, with 'line' as our line
	forM_ text $ \line -> do
		-- 'words' returns an array of strings, every string separated by whitespace in 'line'
		let instructions = words line
		-- instructions!!0 is equivalent to instructions[0]
		let firstWord = instructions!!0
		-- set status equal to the function returned by switchStatus
		let status = switchStatus firstWord
		 -- call status, which will print "toggling" or "turning off or on"
		status

-- equivalent to function switchStatus(var x)
switchStatus x =
	 -- return a function 'print "foo"'
	if x == "toggle" then print "toggling"
	else print "turning off or on"