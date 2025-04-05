#include "Sort.h"

struct TreeNode {
    int value;
    TreeNode* left;
    TreeNode* right;

    TreeNode(int val) : value(val), left(nullptr), right(nullptr) {}
};

TreeNode* Insert(TreeNode* root, int value) {
    if (!root) return new TreeNode(value);
    if (value < root->value)
        root->left = Insert(root->left, value);
    else
        root->right = Insert(root->right, value);
    return root;
}

void InOrderTraversal(TreeNode* root, std::vector<int>& result) {
    if (!root) return;
    InOrderTraversal(root->left, result);
    result.push_back(root->value);
    InOrderTraversal(root->right, result);
}

void DeleteTree(TreeNode* root) {
    if (!root) return;
    DeleteTree(root->left);
    DeleteTree(root->right);
    delete root;
}

void TreeSortUtils::Sort(std::vector<int>& vec) {
    TreeNode* root = nullptr;
    for (int num : vec) {
        root = Insert(root, num);
    }

    std::vector<int> sorted;
    InOrderTraversal(root, sorted);
    vec = sorted;

    DeleteTree(root);
}