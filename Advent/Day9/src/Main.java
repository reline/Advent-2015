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

        locations.forEach(location->System.out.println(location.getName()));
    }


}
