import setuptools

setuptools.setup(
    name="simple",
    version="0.1.9",
    packages=setuptools.find_packages(),
    python_requires=">=3.7",
    install_requires=[
        "OpenAlchemy",
    ],
    include_package_data=True,
)
