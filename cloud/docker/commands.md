# Docker Commands
1. Version: `docker -version`
2. Pulling an image: `docker pull <image-name>:<tag>`
   1. This will pull image from (hub.docker.com)
   2. If tag value is not passed then latest will be referred.
3. Pulling image from own registry:
   1. Login to registry: docker login <registry>
   2. Pulling an image`docker pull <registry>/<image>:<tag>`
   3. If tag is omitted the image with tag latest will be pulled 
   4. Verify pulled image: `docker images` - check if the pulled image shows in list of images
4. Create a container using image: `docker run -it -d <image_name>`
5. Create a container in interactive mode: `docker run -it <image> <command>`
6. List all running containers: `docker ps`
7. List all running + exited containers: `docker ps -a`
8. Access a running container: `docker exec -it <container id> bash`
9. Stopping a container: `docker stop <container-id>`
10. Killing a container(Stopping a container immediately): `docker kill <container-id>`
11. Pushing an image: `docker push <username/image name>`