import matplotlib.pyplot as plt
from shapely.geometry import Polygon
from shapely.ops import unary_union

def plot_polygon(ax, polygon, color='lightblue', edge_color='black'):
    if polygon.is_empty:
        return
    x, y = polygon.exterior.xy
    ax.fill(x, y, color=color, edgecolor=edge_color, alpha=0.7)

def input_polygon(prompt):
    print(prompt)
    points = []
    while True:
        inp = input("Введите координаты вершины (x, y) или 'stop' для завершения: ")
        if inp.lower() == 'stop':
            break
        try:
            x, y = map(float, inp.split(','))
            points.append((x, y))
        except ValueError:
            print("Ошибка: введите координаты в формате x, y")
    if len(points) < 3:
        raise ValueError("Многоугольник должен иметь как минимум 3 вершины.")
    return Polygon(points)

polygon = input_polygon("Введите вершины произвольного многоугольника:")

clip_window = input_polygon("Введите вершины отсекающего окна (для выпуклого многоугольник):")

clipped_polygon = polygon.intersection(clip_window)

fig, ax = plt.subplots(figsize=(8, 8))
ax.set_xlim(0, 10)
ax.set_ylim(0, 10)

plot_polygon(ax, polygon, color='lightgray', edge_color='blue')
plot_polygon(ax, clip_window, color='lightgreen', edge_color='green')
plot_polygon(ax, clipped_polygon, color='orange', edge_color='red')
ax.set_title("Отсечение и закрашивание многоугольников")
plt.gca().set_aspect('equal', adjustable='box')
plt.show()
