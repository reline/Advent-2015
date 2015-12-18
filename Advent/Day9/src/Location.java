import java.util.ArrayList;
import java.util.List;

public class Location {

    private String name;
    private boolean visited;
    private List<Pair<Location, Integer>> neighborLocations;

    public Location(String name) {
        this.name = name;
        this.visited = false;
        this.neighborLocations = new ArrayList<>();
    }

    public void addNeighbor(Location neighbor, int distance) {
        this.neighborLocations.add(new Pair<>(neighbor, distance));
    }

    public String getName() {
        return name;
    }
}
