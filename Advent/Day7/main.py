def main():
	inputFile = open("input.txt", "r+");
	example = open("example.txt");
	for line in inputFile:
		x = line.find("->");
		identifier = (line[(x+3):-1]);
		signalInstruction = (line[:-(len(line) - x)]);
		newWire = Wire(identifier, signalInstruction.split( ));
		newWire.getOperator();
		newWire.getDependencies();

	evaluated = []
	for wire in Wire.wires:
		if (Wire.wires[wire].isEvaluated()):
			evaluated.append(wire);

	while (len(Wire.wires) > len(evaluated)):
		for wire in Wire.wires:
			if (not Wire.wires[wire].isEvaluated()):
				count = len(Wire.wires[wire].dependencies);
				for x in Wire.wires[wire].dependencies:
					if x in evaluated:
						count -= 1;
				if (count == 0):
					Wire.wires[wire].evaluate();
					if (Wire.wires[wire].isEvaluated()):
						evaluated.append(wire);

			#print (evaluated);

	for wire in Wire.wires:
		print (Wire.wires[wire]);



class Wire():

	wires = {};

	def __init__(self, identifier, signalInstruction):
		self.identifier = identifier;
		self.signalInstruction = signalInstruction;
		self.signal = 0;
		self.evaluated = False;
		self.dependencies = []
		Wire.wires[self.identifier] = self;		

	def getOperator(self):
		if (len(self.signalInstruction) > 1 and self.signalInstruction[0] != "NOT"):
			self.operator = self.signalInstruction[1];

		elif (self.signalInstruction[0] == "NOT"):
			self.operator = self.signalInstruction[0];

		else:
			self.operator = "";
			if (self.signalInstruction[0].isdigit()):
				self.signal = int(self.signalInstruction[0]);

	def getDependencies(self):
		if (self.operator == "AND" or self.operator == "OR" or self.operator == "RSHIFT" or self.operator == "LSHIFT"):
			if (not self.signalInstruction[0].isdigit()):
				self.dependencies.append(self.signalInstruction[0]);
			if (not self.signalInstruction[2].isdigit()): 
				self.dependencies.append(self.signalInstruction[2]);
		elif (self.operator == "NOT" and not self.signalInstruction[1].isdigit()):
			self.dependencies.append(self.signalInstruction[1]);
		elif (not self.signalInstruction[0].isdigit()):
			self.dependencies.append(self.signalInstruction[0]);
		if (not self.dependencies):
			self.evaluated = True;

	def evaluate(self):
		x = 0;
		y = 0;
		if (self.operator == "AND" or self.operator == "OR" or self.operator == "RSHIFT" or self.operator == "LSHIFT"):
			x = int(self.signalInstruction[0]) if self.signalInstruction[0].isdigit() else Wire.wires[self.signalInstruction[0]].getSignal();
			y = int(self.signalInstruction[2]) if self.signalInstruction[2].isdigit() else Wire.wires[self.signalInstruction[2]].getSignal();
			if (self.operator == "AND"):
				self.signal = x & y;
			elif (self.operator == "OR"):
				self.signal = x | y;
			elif (self.operator == "RSHIFT"):
				self.signal = x >> y;
			elif (self.operator == "LSHIFT"):
				self.signal = x << y;
		elif (self.operator == "NOT"):
			x = int(self.signalInstruction[1]) if self.signalInstruction[1].isdigit() else Wire.wires[self.signalInstruction[1]].getSignal();
			self.signal = 65534 + ~ x;
		else:
			self.signal = int(self.signalInstruction[0]) if self.signalInstruction[0].isdigit() else Wire.wires[self.signalInstruction[0]].getSignal();

		self.evaluated = True;

	def getSignal(self):
		return self.signal;

	def isEvaluated(self):
		return self.evaluated;

	def __str__(self):
		return (self.identifier + ': ' + str(self.signal));
		

if __name__ == "__main__":
    main()