import tkinter as tk
from tkinter import simpledialog, messagebox
import matplotlib.pyplot as plt
import numpy as np

def bezier_quadratic(points, t):
    p0, p1, p2 = points
    return (1 - t) ** 2 * p0 + 2 * (1 - t) * t * p1 + t ** 2 * p2

def bezier_cubic(points, t):
    p0, p1, p2, p3 = points
    return ((1 - t) ** 3) * p0 + 3 * ((1 - t) ** 2) * t * p1 + 3 * (1 - t) * t ** 2 * p2 + t ** 3 * p3

def chaikin_curve(points, iterations):
    for _ in range(iterations):
        new_points = []
        for i in range(len(points) - 1):
            p0 = points[i]
            p1 = points[i + 1]
            new_points.append(0.75 * p0 + 0.25 * p1)
            new_points.append(0.25 * p0 + 0.75 * p1)
        points = np.array(new_points)
    return points

def draw_curve(curve_function, points, divisions=100):
    t_values = np.linspace(0, 1, divisions)
    curve = np.array([curve_function(points, t) for t in t_values])
    plt.plot(curve[:, 0], curve[:, 1], label="Кривая")
    plt.scatter(points[:, 0], points[:, 1], color='red', label="Контрольные точки")
    plt.legend()
    plt.show()

def draw_chaikin(points, iterations):
    refined_points = chaikin_curve(points, iterations)
    plt.plot(refined_points[:, 0], refined_points[:, 1], label="Кривая Чайкина")
    plt.scatter(points[:, 0], points[:, 1], color='red', label="Контрольные точки")
    plt.legend()
    plt.show()

def get_points(number_of_points):
    points = []
    for i in range(number_of_points):
        x = simpledialog.askfloat("Координаты", f"Введите X для точки {i + 1}:")
        y = simpledialog.askfloat("Координаты", f"Введите Y для точки {i + 1}:")
        points.append([x, y])
    return np.array(points)

def bezier_quadratic_ui():
    num_points = 3
    points = get_points(num_points)
    divisions = simpledialog.askinteger("Разбиение", "Введите количество делений (например, 100):")
    draw_curve(bezier_quadratic, points, divisions)

def bezier_cubic_ui():
    num_points = 4
    points = get_points(num_points)
    divisions = simpledialog.askinteger("Разбиение", "Введите количество делений (например, 100):")
    draw_curve(bezier_cubic, points, divisions)

def chaikin_ui():
    num_points = simpledialog.askinteger("Точки", "Введите количество контрольных точек (минимум 4):")
    if num_points < 4:
        messagebox.showerror("Ошибка", "Количество точек должно быть минимум 4.")
        return
    points = get_points(num_points)
    iterations = simpledialog.askinteger("Итерации", "Введите количество итераций сглаживания:")
    draw_chaikin(points, iterations)

def main():
    root = tk.Tk()
    root.withdraw()
    while True:
        choice = simpledialog.askstring("Меню", "Выберите метод:\n1: Квадратичная кривая Безье\n2: Кубическая кривая Безье\n3: Кривая Чайкина\nQ: Выйти")
        if not choice:
            break
        if choice.lower() == 'q':
            break
        elif choice == '1':
            bezier_quadratic_ui()
        elif choice == '2':
            bezier_cubic_ui()
        elif choice == '3':
            chaikin_ui()
        else:
            messagebox.showerror("Ошибка", "Неверный ввод, попробуйте снова.")

if __name__ == "__main__":
    main()
