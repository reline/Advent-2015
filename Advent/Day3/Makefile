# dirs = $(shell ls -d */)
date = $(shell date +%-d)

all:
	# ifeq $(4 -gt 25)
		# $(foreach dir,$(dirs),mcs $(dir)/*.cs;)
	@echo Compiling...
	@mcs *.cs
	@echo Running...
	@mono *.exe
	@echo Done.