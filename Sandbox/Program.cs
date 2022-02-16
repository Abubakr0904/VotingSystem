var yes = new Counter("Yes", 4);
var no = new Counter("No", 4);
var maybe = new Counter("Maybe", 4);
var hopefully = new Counter("Hopefully", 4);

var manager = new CounterManager( yes, no, maybe, hopefully );

manager.AnnounceWinner();