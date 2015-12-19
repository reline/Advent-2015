import java.util.ArrayList;
import java.util.List;

public class Location {

    private String name;
    private boolean visited;
    public List<Pair<Location, Integer>> neighborLocations;
    private int tentativeDistance;

    public Location(String name) {
        this.name = name;
        this.visited = false;
        this.neighborLocations = new ArrayList<>();
        tentativeDistance = Integer.MAX_VALUE;
    }

    public void addNeighbor(Location neighbor, int distance) {
        this.neighborLocations.add(new Pair<>(neighbor, distance));
    }

    public boolean visited() {
        return this.visited;
    }

    public void visit() {
        this.visited = true;
    }

    public void updateTentativeDistance(int newDistance) {
        this.tentativeDistance = newDistance;
    }

    public int getTentativeDistance() {
        return this.tentativeDistance;
    }

    public String getName() {
        return name;
    }

    public void reset() {
        this.visited = false;
        this.tentativeDistance = Integer.MAX_VALUE;
    }
}
