#!/bin/bash
set -e

# Initialize git if not already
git init

# Configure local git to avoid global config issues in the sandbox
git config user.name "Heer12354"
git config user.email "heer@example.com"

# Add all files
git add .

# Commit
git commit -m "Initial commit with GitHub Actions release workflow" || echo "Nothing to commit"

# Create a repo on GitHub and push the code
gh repo create "ai-app-formula-1" --public --source=. --remote=origin --push
