import sys
import re
from anytree import Node

MAX_NODES = 500

def parse_tree_output(lines):
    root = Node("root")
    stack = [root]
    node_count = 0

    for line in lines:
        if node_count >= MAX_NODES:
            break

        line = line.rstrip()
        if not line:
            continue

        # Contar niveles basado en estructura de tree en Windows
        indent = line.count("│") + line.count("    ")
        name = re.sub(r'^[│├└─\s]+', '', line)

        # Ajustar stack según nivel
        while len(stack) > indent + 1:
            stack.pop()

        parent = stack[-1]
        node = Node(name, parent=parent)
        stack.append(node)
        node_count += 1

    return root


def generate_mermaid(root):
    lines = ["graph TD"]
    node_id = 0

    def walk(node, parent_id=None):
        nonlocal node_id

        current_id = f"id{node_id}"
        label = node.name.replace('"', '\\"')
        lines.append(f'{current_id}["{label}"]')

        if parent_id:
            lines.append(f"{parent_id} --> {current_id}")

        node_id += 1

        for child in node.children:
            walk(child, current_id)

    for child in root.children:
        walk(child)

    return "\n".join(lines)


def main():
    lines = sys.stdin.readlines()
    root = parse_tree_output(lines)
    print(generate_mermaid(root))


if __name__ == "__main__":
    main()