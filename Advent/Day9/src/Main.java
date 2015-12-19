import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        List<Location> locations = new ArrayList<>();
        List<String> locationsList = new ArrayList<>();

        File input = new File("input.txt");
        try(BufferedReader br = new BufferedReader(new FileReader(input))) {
            for(String line; (line = br.readLine()) != null; ) {

                List<String> split = new ArrayList<>();
                Collections.addAll(split, line.split(" ", 5));
                String location1Name = split.get(0);
                Location location1 = new Location(location1Name);
                String location2Name = split.get(2);
                Location location2 = new Location(location2Name);
                String distance = split.get(4);

                if (!locationsList.contains(location1Name) && !locationsList.contains(location2Name)) {
                    location1.addNeighbor(location2, Integer.parseInt(distance));
                    locations.add(location1);
                    locationsList.add(location1Name);

                    location2.addNeighbor(location1, Integer.parseInt(distance));
                    locations.add(location2);
                    locationsList.add(location2Name);
                }

                else if (locationsList.contains(location1Name) && locationsList.contains(location2Name)) {
                    // find both locations and add each other as neighbors
                    int location1Index = 0;
                    int location2Index = 0;
                    for (int i = 0; i < locations.size(); i++) {
                        if (locations.get(i).getName().equals(location1Name)) {
                            location1Index = i;
                        } else if (locations.get(i).getName().equals(location2Name)) {
                            location2Index = i;
                        }
                    }
                    locations.get(location1Index).addNeighbor(locations.get(location2Index), Integer.parseInt(distance));
                    locations.get(location2Index).addNeighbor(locations.get(location1Index), Integer.parseInt(distance));
                }

                else if (locationsList.contains(location1Name) && !locationsList.contains(location2Name)) {
                    // find location1 and add location2 as neighbor
                    locations.stream().filter(location -> location.getName().equals(location1Name)).forEach(location -> {
                        location2.addNeighbor(location, Integer.parseInt(distance));
                        location.addNeighbor(location2, Integer.parseInt(distance));
                    });
                    locations.add(location2);
                    locationsList.add(location2Name);
                }

                else if (!locationsList.contains(location1Name) && locationsList.contains(location2Name)) {
                    // find location2 and add location1 as neighbor
                    locations.stream().filter(location -> location.getName().equals(location2Name)).forEach(location -> {
                        location1.addNeighbor(location, Integer.parseInt(distance));
                        location.addNeighbor(location1, Integer.parseInt(distance));
                    });
                    locations.add(location1);
                    locationsList.add(location1Name);
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        int shortestPath = Integer.MAX_VALUE;
        for (Location location : locations) {
            int dijkstra = dijkstra(location);
            if (dijkstra < shortestPath)
                shortestPath = dijkstra;
        }

        System.out.println("Solution: " + shortestPath); // 117 is the answer for part one Faerun->AlphaCentauri->Tambi->Snowdin->Norrath->Tristram->Arbre->Straylight
        // part 2: 833 too low, 1078 too high
    }

    static int dijkstra(Location initLocation) {
        Location currentLocation = initLocation;
        List<Location> visited = new ArrayList<>();

        while(true) {
            boolean allVisited = true;
            Pair<Location, Integer> shortestTentativeDistance = new Pair<>(new Location("North Pole"), Integer.MAX_VALUE);

            // add currentlocation to visited list
            currentLocation.visit();
            if (!visited.contains(currentLocation)) {
                visited.add(currentLocation);
            }

            // if all of the locations have been visited, return our lowest tentative value
            for (Pair<Location, Integer> neighbor : currentLocation.neighborLocations) {
                if (!(neighbor.getFirst().visited())) {
                    allVisited = false;
                }
            }
            if (allVisited) {
                // save our solution
                int solution = currentLocation.getTentativeDistance();

                // reset our nodes! dumbass!
                for (Location visitedLocation : visited) {
                    visitedLocation.reset();
                }

                return solution;
            }


            // iterate through visited list
            for (Location visitedLocation : visited) {
                // iterate through neighbor list
                for (Pair<Location, Integer> neighbor : visitedLocation.neighborLocations) {
                    if (!(neighbor.getFirst().visited())) {

                        // calculate tentative values

                        // fix max stuff
                        if (visitedLocation.getTentativeDistance() == Integer.MAX_VALUE) {
                            visitedLocation.updateTentativeDistance(0);
                        }
                        if (neighbor.getFirst().getTentativeDistance() == Integer.MAX_VALUE) {
                            neighbor.getFirst().updateTentativeDistance(
                                    neighbor.getSecond()
                            );
                        }

                        int tentVal = currentLocation.getTentativeDistance() + neighbor.getSecond();
                        if (tentVal < neighbor.getFirst().getTentativeDistance()) {
                            neighbor.getFirst().updateTentativeDistance(tentVal);
                        }

                        // set the lowest tentative value of all of the neighbors
                        if (neighbor.getFirst().getTentativeDistance() < shortestTentativeDistance.getFirst().getTentativeDistance()) {
                            shortestTentativeDistance = neighbor;
                        }
                    }
                }
            }

            // change our current location
            currentLocation = shortestTentativeDistance.getFirst();
            //totalDistance = shortestTentativeDistance.getFirst().getTentativeDistance();
        }
    }
}
