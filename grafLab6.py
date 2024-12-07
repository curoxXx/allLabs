import matplotlib.pyplot as plt

def is_inside(x, y, win_xmin, win_xmax, win_ymin, win_ymax):
    return win_xmin <= x <= win_xmax and win_ymin <= y <= win_ymax

def midpoint_subdivision(line, win_xmin, win_xmax, win_ymin, win_ymax):
    x1, y1 = line[0]
    x2, y2 = line[1]

    if is_inside(x1, y1, win_xmin, win_xmax, win_ymin, win_ymax) and is_inside(x2, y2, win_xmin, win_xmax, win_ymin,
                                                                               win_ymax):
        return [(x1, y1), (x2, y2)]

    if not is_inside(x1, y1, win_xmin, win_xmax, win_ymin, win_ymax) and not is_inside(x2, y2, win_xmin, win_xmax,
                                                                                       win_ymin, win_ymax):
        return None

    xm, ym = (x1 + x2) / 2, (y1 + y2) / 2
    if abs(x1 - x2) < 0.01 and abs(y1 - y2) < 0.01:
        return None

    if is_inside(xm, ym, win_xmin, win_xmax, win_ymin, win_ymax):
        if is_inside(x1, y1, win_xmin, win_xmax, win_ymin, win_ymax):
            return [(x1, y1), (xm, ym)]
        else:
            return [(xm, ym), (x2, y2)]
    else:
        left_clip = midpoint_subdivision([(x1, y1), (xm, ym)], win_xmin, win_xmax, win_ymin, win_ymax)
        right_clip = midpoint_subdivision([(xm, ym), (x2, y2)], win_xmin, win_xmax, win_ymin, win_ymax)
        return left_clip or right_clip

def sutherland_cohen(line, win_xmin, win_xmax, win_ymin, win_ymax):
    x1, y1 = line[0]
    x2, y2 = line[1]

    def compute_outcode(x, y):
        code = 0
        if x < win_xmin: code |= 1
        if x > win_xmax: code |= 2
        if y < win_ymin: code |= 4
        if y > win_ymax: code |= 8
        return code

    outcode1 = compute_outcode(x1, y1)
    outcode2 = compute_outcode(x2, y2)

    while True:
        if outcode1 == 0 and outcode2 == 0:
            return [(x1, y1), (x2, y2)]
        if (outcode1 & outcode2) != 0:
            return None

        outcode_out = outcode1 if outcode1 != 0 else outcode2
        if outcode_out & 1:
            y = y1 + (y2 - y1) * (win_xmin - x1) / (x2 - x1)
            x = win_xmin
        elif outcode_out & 2:
            y = y1 + (y2 - y1) * (win_xmax - x1) / (x2 - x1)
            x = win_xmax
        elif outcode_out & 4:
            x = x1 + (x2 - x1) * (win_ymin - y1) / (y2 - y1)
            y = win_ymin
        else:
            x = x1 + (x2 - x1) * (win_ymax - y1) / (y2 - y1)
            y = win_ymax

        if outcode_out == outcode1:
            x1, y1 = x, y
            outcode1 = compute_outcode(x1, y1)
        else:
            x2, y2 = x, y
            outcode2 = compute_outcode(x2, y2)

def visualize(lines, clipped_lines, win_xmin, win_xmax, win_ymin, win_ymax, title):
    plt.figure()
    plt.title(title)
    plt.xlabel("X")
    plt.ylabel("Y")
    plt.xlim(win_xmin - 10, win_xmax + 10)
    plt.ylim(win_ymin - 10, win_ymax + 10)
    plt.plot([win_xmin, win_xmax, win_xmax, win_xmin, win_xmin], [win_ymin, win_ymin, win_ymax, win_ymax, win_ymin],
             'g-')

    for line in lines:
        plt.plot([line[0][0], line[1][0]], [line[0][1], line[1][1]], 'b--')

    for line in clipped_lines:
        if line:
            plt.plot([line[0][0], line[1][0]], [line[0][1], line[1][1]], 'r-')

    plt.grid()
    plt.show()

if __name__ == "__main__":
    win_xmin, win_xmax = map(float, input("Введите win_xmin и win_xmax(win_xmin win_xmax): ").split())
    win_ymin, win_ymax = map(float, input("Введите win_ymin и win_ymax(win_ymin win_ymax): ").split())
    num_lines = int(input("Введите количество отрезков: "))

    lines = []
    for i in range(num_lines):
        x1, y1, x2, y2 = map(float, input(f"Введите координаты отрезка {i + 1} (x1 y1 x2 y2): ").split())
        lines.append([(x1, y1), (x2, y2)])

    clipped_sutherland = [sutherland_cohen(line, win_xmin, win_xmax, win_ymin, win_ymax) for line in lines]
    clipped_midpoint = [midpoint_subdivision(line, win_xmin, win_xmax, win_ymin, win_ymax) for line in lines]
    print("Алгоритм Сазерленда-Коэна:")
    visualize(lines, clipped_sutherland, win_xmin, win_xmax, win_ymin, win_ymax, "Алгоритм Сазерленда-Коэна")
    print("Алгоритм разбиения средней точкой:")
    visualize(lines, clipped_midpoint, win_xmin, win_xmax, win_ymin, win_ymax, "Алгоритм разбиения средней точкой")
