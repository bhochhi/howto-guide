1. [Python setup for mac](https://sourabhbajaj.com/mac-setup/Python/)
2. [Managing dependencies in python project](https://packaging.python.org/tutorials/managing-dependencies/)
3. [pipenv usage](https://pipenv.readthedocs.io/en/latest/basics/)
4. Importing from requirements.txt : 
    ```$ pipenv install -r path/to/requirements.txt```
5. Create requirements.txt from project : ```$pip freeze > requirements.txt``` or ```pip install pipreqs``` then ```pipreqs path/to/project```
6. [Packaging Python Projects](https://packaging.python.org/tutorials/packaging-projects/)
7. [Python Modules and Packages](https://docs.python.org/3/tutorial/modules.html#packages)
8. [Generating dist. package](https://packaging.python.org/tutorials/packaging-projects/#generating-distribution-archives)
9. [Flask web app: quickstart](http://flask.pocoo.org/docs/1.0/quickstart/#quickstart)

Manage python using pyenv
---
To manage multiple version of python and package management, I like using pyenv.
- install pyenv: ```$ brew install pyenv``` 
- enable shims and autocompletion : ``` echo 'eval "$(pyenv init -)"' >> ~/.zshrc```
- reload: ```exec $SHELL```
- list installed pythons: ```pyenv install --list```
- to set global versions of Python to be used in all shells: ```pyenv global 2.7.12 3.5.2``` ```pyenv rehash```
- to set local version of python to be use in a shells: ```cd path/to/directory``` ```pyenv local 3.7``` it creates .python-version file in the directory.
- now whenever you are on the project directory, it will start using python 3.7

Manage packages/dependencies using pipenv
--- 
- pipenv is similar to npm as python to node and nvm to pyenv
- Install pipenv: ```pip install -U pipenv```
- Install project dependencies: cd to project directory>> ```pipenv install```
    it will create pipfile and pipfile.lock files. just like npm creating package.json and package.lock.json file. 
- To add registry/repository: add to pipfile as:
        [[source]]
        url = "https://www.registry..."
        verify_ssl = true
        name = "other repo"
- when installing package, pipevn try to find the package from listed sources, but if you want to install for particular index you can also do: 
        [packages]
        flask = "*"
        your-package = {version="*", index="other repo"}
- Just like you can run script using npm run <script> you can do same using pyevn run <script> where in pipfile:
    [scripts]
    <script> = "python app.py runscript"
    


       
