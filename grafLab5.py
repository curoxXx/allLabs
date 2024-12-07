import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
import numpy as np

def draw_polyhedron(vertices, edges, projection="orthogonal", title="Polyhedron"):
    fig = plt.figure()
    ax = fig.add_subplot(111, projection='3d')
    if projection == "central":
        ax.dist = 10
    elif projection == "orthogonal":
        ax.dist = 7
    for edge in edges:
        x_coords = [vertices[edge[0]][0], vertices[edge[1]][0]]
        y_coords = [vertices[edge[0]][1], vertices[edge[1]][1]]
        z_coords = [vertices[edge[0]][2], vertices[edge[1]][2]]
        ax.plot(x_coords, y_coords, z_coords, color="red")
    ax.set_title(title)
    ax.set_xlabel("X")
    ax.set_ylabel("Y")
    ax.set_zlabel("Z")
    plt.show()

def hex():
    vertices = [
        [-1, -1, -1], [1, -1, -1], [1, 1, -1], [-1, 1, -1],
        [-1, -1, 1], [1, -1, 1], [1, 1, 1], [-1, 1, 1]
    ]
    edges = [
        (0, 1), (1, 2), (2, 3), (3, 0),
        (4, 5), (5, 6), (6, 7), (7, 4),
        (0, 4), (1, 5), (2, 6), (3, 7)
    ]
    return vertices, edges
def octah():
    vertices = [
        [0, 0, -1], [1, 0, 0], [0, 1, 0], [-1, 0, 0], [0, -1, 0], [0, 0, 1]
    ]
    edges = [
        (0, 1), (0, 2), (0, 3), (0, 4),
        (5, 1), (5, 2), (5, 3), (5, 4),
        (1, 2), (2, 3), (3, 4), (4, 1)
    ]
    return vertices, edges

if __name__ == "__main__":
    vertices, edges = hex()
    draw_polyhedron(vertices, edges, projection="orthogonal", title="Гексаэдр")

    vertices, edges = octah()
    draw_polyhedron(vertices, edges, projection="central", title="Октаэдр")