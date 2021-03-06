//
// The Open Toolkit Library License
//
// Copyright (c) 2006 - 2013 Stefanos Apostolopoulos for the Open Toolkit Library
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights to 
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do
// so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
//

namespace OpenTK.Compute.CL10
{
    using System;
    using System.Runtime.InteropServices;
    using OpenTK.Extensions;


    /// <summary>
    /// Defines methods to simplify CommandQueue usage.
    /// </summary>
    public partial struct CommandQueue : IComparable<CommandQueue>, IEquatable<CommandQueue>
    {
        internal IntPtr Value;

        #region IComparable<CommandQueue> Implementation

        /// <summary>
        /// Returns the sort order of the current instance compared to the specified <see cref="CommandQueue"/>.
        /// </summary>
        /// <param name="other">The <see cref="CommandQueue"/> to compare with the current <see cref="CommandQueue"/>.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        public int CompareTo(CommandQueue other)
        {
            int result = 0;
            if (result == 0)
                result = Value.CompareTo(other.Value);
            return result;
        }

        #endregion

        #region IEquatable<CommandQueue> Implementation

        /// <summary>
        /// Determines whether the specified <see cref="CommandQueue"/> is equal to the current <see cref="CommandQueue"/>.
        /// </summary>
        /// <param name="other">The <see cref="CommandQueue"/> to compare with the current <see cref="CommandQueue"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="CommandQueue"/> is equal to the current
        /// <see cref="CommandQueue"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(CommandQueue other)
        {
            bool result = true;
            result &= Value.Equals(other.Value);
            return result;
        }

        #endregion

        #region Public Members

        /// <summary>Defines a zero (or null) <see cref="CommandQueue"/></summary>
        public static readonly CommandQueue Zero = new CommandQueue();

        /// <summary>Tests two <see cref="CommandQueue"/> instances for equality.</summary>
        public static bool operator ==(CommandQueue left, CommandQueue right)
        {
            return left.Equals(right);
        }

        /// <summary>Tests two <see cref="CommandQueue"/> instances for inequality.</summary>
        public static bool operator !=(CommandQueue left, CommandQueue right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="CommandQueue"/>.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with the current <see cref="CommandQueue"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="CommandQueue"/> is equal to the current
        /// <see cref="CommandQueue"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object other)
        {
            return other is CommandQueue && Equals((CommandQueue)other);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="CommandQueue"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= Value.GetHashCode();
            return hash;
        }

        #endregion
    }

    /// <summary>
    /// Defines methods to simplify CommandQueue usage.
    /// </summary>
    public static partial class CommandQueueExtensions
    {
        /// <summary>[requires: v1.0]
        /// A synchronization point that enqueues a barrier operation.
        /// </summary>
        /// <param name="command_queue"></param>
        public static ErrorCode EnqueueBarrier(this CommandQueue command_queue)
        {
            return CL.EnqueueBarrier(command_queue);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to copy a buffer object to another buffer object.
        /// </summary>
        /// <param name="command_queue"> 
        /// The command-queue in which the copy command will be queued. The OpenCL context associated with command_queue, src_buffer, and dst_buffer must be the same.
        /// </param>
        /// <param name="src_buffer"> 
        /// The offset where to begin copying data from src_buffer.
        /// </param>
        /// <param name="dst_buffer"> 
        /// The offset where to begin copying data into dst_buffer.
        /// </param>
        /// <param name="src_offset"> 
        /// The offset where to begin copying data from src_buffer.
        /// </param>
        /// <param name="dst_offset"> 
        /// The offset where to begin copying data into dst_buffer.
        /// </param>
        /// <param name="cb"> 
        /// Refers to the size in bytes to copy.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueCopyBuffer(this CommandQueue command_queue, ComputeMemory src_buffer, ComputeMemory dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueCopyBuffer(command_queue, src_buffer, dst_buffer, src_offset, dst_offset, cb, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to copy a buffer object to another buffer object.
        /// </summary>
        /// <param name="command_queue"> 
        /// The command-queue in which the copy command will be queued. The OpenCL context associated with command_queue, src_buffer, and dst_buffer must be the same.
        /// </param>
        /// <param name="src_buffer"> 
        /// The offset where to begin copying data from src_buffer.
        /// </param>
        /// <param name="dst_buffer"> 
        /// The offset where to begin copying data into dst_buffer.
        /// </param>
        /// <param name="src_offset"> 
        /// The offset where to begin copying data from src_buffer.
        /// </param>
        /// <param name="dst_offset"> 
        /// The offset where to begin copying data into dst_buffer.
        /// </param>
        /// <param name="cb"> 
        /// Refers to the size in bytes to copy.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueCopyBuffer(this CommandQueue command_queue, ComputeMemory src_buffer, ComputeMemory dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueCopyBuffer(command_queue, src_buffer, dst_buffer, src_offset, dst_offset, cb, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to copy a buffer object to another buffer object.
        /// </summary>
        /// <param name="command_queue"> 
        /// The command-queue in which the copy command will be queued. The OpenCL context associated with command_queue, src_buffer, and dst_buffer must be the same.
        /// </param>
        /// <param name="src_buffer"> 
        /// The offset where to begin copying data from src_buffer.
        /// </param>
        /// <param name="dst_buffer"> 
        /// The offset where to begin copying data into dst_buffer.
        /// </param>
        /// <param name="src_offset"> 
        /// The offset where to begin copying data from src_buffer.
        /// </param>
        /// <param name="dst_offset"> 
        /// The offset where to begin copying data into dst_buffer.
        /// </param>
        /// <param name="cb"> 
        /// Refers to the size in bytes to copy.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueCopyBuffer(this CommandQueue command_queue, ComputeMemory src_buffer, ComputeMemory dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
        {
            return CL.EnqueueCopyBuffer(command_queue, src_buffer, dst_buffer, src_offset, dst_offset, cb, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to copy a buffer object to an image object.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. The OpenCL context associated with command_queue, src_buffer, and dst_image must be the same.
        /// </param>
        /// <param name="src_buffer"> 
        /// A valid buffer object.
        /// </param>
        /// <param name="dst_image"> 
        /// A valid image object.
        /// </param>
        /// <param name="src_offset"> 
        /// The offset where to begin copying data from src_buffer.
        /// </param>
        /// <param name="dst_origin">[length: 3] 
        /// The (x, y, z) offset in pixels where to begin copying data to dst_image. If dst_image is a 2D image object, the z value given by dst_origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle to copy. If dst_image is a 2D image object, the depth value given by region[2] must be 1.  The size in bytes of the region to be copied from src_buffer referred to as src_cb is computed as width * height * depth * bytes/image element if dst_image is a 3D image object and is computed as width * height * bytes/image element if dst_image is a 2D image object.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueCopyBufferToImage(this CommandQueue command_queue, ComputeMemory src_buffer, ComputeMemory dst_image, IntPtr src_offset, IntPtr*[] dst_origin, IntPtr*[] region, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueCopyBufferToImage(command_queue, src_buffer, dst_image, src_offset, dst_origin, region, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to copy a buffer object to an image object.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. The OpenCL context associated with command_queue, src_buffer, and dst_image must be the same.
        /// </param>
        /// <param name="src_buffer"> 
        /// A valid buffer object.
        /// </param>
        /// <param name="dst_image"> 
        /// A valid image object.
        /// </param>
        /// <param name="src_offset"> 
        /// The offset where to begin copying data from src_buffer.
        /// </param>
        /// <param name="dst_origin">[length: 3] 
        /// The (x, y, z) offset in pixels where to begin copying data to dst_image. If dst_image is a 2D image object, the z value given by dst_origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle to copy. If dst_image is a 2D image object, the depth value given by region[2] must be 1.  The size in bytes of the region to be copied from src_buffer referred to as src_cb is computed as width * height * depth * bytes/image element if dst_image is a 3D image object and is computed as width * height * bytes/image element if dst_image is a 2D image object.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueCopyBufferToImage(this CommandQueue command_queue, ComputeMemory src_buffer, ComputeMemory dst_image, IntPtr src_offset, ref IntPtr* dst_origin, ref IntPtr* region, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueCopyBufferToImage(command_queue, src_buffer, dst_image, src_offset, ref dst_origin, ref region, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to copy a buffer object to an image object.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. The OpenCL context associated with command_queue, src_buffer, and dst_image must be the same.
        /// </param>
        /// <param name="src_buffer"> 
        /// A valid buffer object.
        /// </param>
        /// <param name="dst_image"> 
        /// A valid image object.
        /// </param>
        /// <param name="src_offset"> 
        /// The offset where to begin copying data from src_buffer.
        /// </param>
        /// <param name="dst_origin">[length: 3] 
        /// The (x, y, z) offset in pixels where to begin copying data to dst_image. If dst_image is a 2D image object, the z value given by dst_origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle to copy. If dst_image is a 2D image object, the depth value given by region[2] must be 1.  The size in bytes of the region to be copied from src_buffer referred to as src_cb is computed as width * height * depth * bytes/image element if dst_image is a 3D image object and is computed as width * height * bytes/image element if dst_image is a 2D image object.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueCopyBufferToImage(this CommandQueue command_queue, ComputeMemory src_buffer, ComputeMemory dst_image, IntPtr src_offset, IntPtr** dst_origin, IntPtr** region, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
        {
            return CL.EnqueueCopyBufferToImage(command_queue, src_buffer, dst_image, src_offset, dst_origin, region, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to copy image objects.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the copy command will be queued. The OpenCL context associated with command_queue, src_image and dst_image must be the same.
        /// </param>
        /// <param name="src_image"> 
        /// Defines the starting (x, y, z) location in pixels in src_image from where to start the data copy. If src_image is a 2D image object, the z value given by src_origin[2] must be 0.
        /// </param>
        /// <param name="dst_image"> 
        /// Defines the starting (x, y, z) location in pixels in dst_image from where to start the data copy. If dst_image is a 2D image object, the z value given by dst_origin[2] must be 0.
        /// </param>
        /// <param name="src_origin">[length: 3] 
        /// Defines the starting (x, y, z) location in pixels in src_image from where to start the data copy. If src_image is a 2D image object, the z value given by src_origin[2] must be 0.
        /// </param>
        /// <param name="dst_origin">[length: 3] 
        /// Defines the starting (x, y, z) location in pixels in dst_image from where to start the data copy. If dst_image is a 2D image object, the z value given by dst_origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle to copy. If src_image or dst_image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueCopyImage(this CommandQueue command_queue, ComputeMemory src_image, ComputeMemory dst_image, IntPtr*[] src_origin, IntPtr*[] dst_origin, IntPtr*[] region, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueCopyImage(command_queue, src_image, dst_image, src_origin, dst_origin, region, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to copy image objects.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the copy command will be queued. The OpenCL context associated with command_queue, src_image and dst_image must be the same.
        /// </param>
        /// <param name="src_image"> 
        /// Defines the starting (x, y, z) location in pixels in src_image from where to start the data copy. If src_image is a 2D image object, the z value given by src_origin[2] must be 0.
        /// </param>
        /// <param name="dst_image"> 
        /// Defines the starting (x, y, z) location in pixels in dst_image from where to start the data copy. If dst_image is a 2D image object, the z value given by dst_origin[2] must be 0.
        /// </param>
        /// <param name="src_origin">[length: 3] 
        /// Defines the starting (x, y, z) location in pixels in src_image from where to start the data copy. If src_image is a 2D image object, the z value given by src_origin[2] must be 0.
        /// </param>
        /// <param name="dst_origin">[length: 3] 
        /// Defines the starting (x, y, z) location in pixels in dst_image from where to start the data copy. If dst_image is a 2D image object, the z value given by dst_origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle to copy. If src_image or dst_image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueCopyImage(this CommandQueue command_queue, ComputeMemory src_image, ComputeMemory dst_image, ref IntPtr* src_origin, ref IntPtr* dst_origin, ref IntPtr* region, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueCopyImage(command_queue, src_image, dst_image, ref src_origin, ref dst_origin, ref region, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to copy image objects.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the copy command will be queued. The OpenCL context associated with command_queue, src_image and dst_image must be the same.
        /// </param>
        /// <param name="src_image"> 
        /// Defines the starting (x, y, z) location in pixels in src_image from where to start the data copy. If src_image is a 2D image object, the z value given by src_origin[2] must be 0.
        /// </param>
        /// <param name="dst_image"> 
        /// Defines the starting (x, y, z) location in pixels in dst_image from where to start the data copy. If dst_image is a 2D image object, the z value given by dst_origin[2] must be 0.
        /// </param>
        /// <param name="src_origin">[length: 3] 
        /// Defines the starting (x, y, z) location in pixels in src_image from where to start the data copy. If src_image is a 2D image object, the z value given by src_origin[2] must be 0.
        /// </param>
        /// <param name="dst_origin">[length: 3] 
        /// Defines the starting (x, y, z) location in pixels in dst_image from where to start the data copy. If dst_image is a 2D image object, the z value given by dst_origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle to copy. If src_image or dst_image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueCopyImage(this CommandQueue command_queue, ComputeMemory src_image, ComputeMemory dst_image, IntPtr** src_origin, IntPtr** dst_origin, IntPtr** region, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
        {
            return CL.EnqueueCopyImage(command_queue, src_image, dst_image, src_origin, dst_origin, region, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to copy an image object to a buffer object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue. The OpenCL context associated with  command_queue, src_image, and dst_buffer must be the same.
        /// </param>
        /// <param name="src_image"> 
        /// A valid image object.
        /// </param>
        /// <param name="dst_buffer"> 
        /// A valid buffer object.
        /// </param>
        /// <param name="src_origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to copy. If src_image is a 2D image object, the z value given by src_origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle to copy. If src_image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="dst_offset"> 
        /// The offset where to begin copying data into dst_buffer. The size in bytes of the region to be copied referred to as dst_cb is computed as width * height * depth * bytes/image element if src_image is a 3D image object and is computed as width * height * bytes/image element if src_image is a 2D image object.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueCopyImageToBuffer(this CommandQueue command_queue, ComputeMemory src_image, ComputeMemory dst_buffer, IntPtr*[] src_origin, IntPtr*[] region, IntPtr dst_offset, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueCopyImageToBuffer(command_queue, src_image, dst_buffer, src_origin, region, dst_offset, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to copy an image object to a buffer object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue. The OpenCL context associated with  command_queue, src_image, and dst_buffer must be the same.
        /// </param>
        /// <param name="src_image"> 
        /// A valid image object.
        /// </param>
        /// <param name="dst_buffer"> 
        /// A valid buffer object.
        /// </param>
        /// <param name="src_origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to copy. If src_image is a 2D image object, the z value given by src_origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle to copy. If src_image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="dst_offset"> 
        /// The offset where to begin copying data into dst_buffer. The size in bytes of the region to be copied referred to as dst_cb is computed as width * height * depth * bytes/image element if src_image is a 3D image object and is computed as width * height * bytes/image element if src_image is a 2D image object.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueCopyImageToBuffer(this CommandQueue command_queue, ComputeMemory src_image, ComputeMemory dst_buffer, ref IntPtr* src_origin, ref IntPtr* region, IntPtr dst_offset, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueCopyImageToBuffer(command_queue, src_image, dst_buffer, ref src_origin, ref region, dst_offset, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to copy an image object to a buffer object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue. The OpenCL context associated with  command_queue, src_image, and dst_buffer must be the same.
        /// </param>
        /// <param name="src_image"> 
        /// A valid image object.
        /// </param>
        /// <param name="dst_buffer"> 
        /// A valid buffer object.
        /// </param>
        /// <param name="src_origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to copy. If src_image is a 2D image object, the z value given by src_origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle to copy. If src_image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="dst_offset"> 
        /// The offset where to begin copying data into dst_buffer. The size in bytes of the region to be copied referred to as dst_cb is computed as width * height * depth * bytes/image element if src_image is a 3D image object and is computed as width * height * bytes/image element if src_image is a 2D image object.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueCopyImageToBuffer(this CommandQueue command_queue, ComputeMemory src_image, ComputeMemory dst_buffer, IntPtr** src_origin, IntPtr** region, IntPtr dst_offset, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
        {
            return CL.EnqueueCopyImageToBuffer(command_queue, src_image, dst_buffer, src_origin, region, dst_offset, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to map a region of the buffer object given by buffer into the host address space and returns a pointer to this mapped region.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="buffer"> 
        /// A valid buffer object. The OpenCL context associated with command_queue and buffer must be the same.
        /// </param>
        /// <param name="blocking_map"> 
        /// Indicates if the map operation is blocking or non-blocking.  If blocking_map is True, clEnqueueMapBuffer does not return until the specified region in buffer can be mapped.  If blocking_map is False i.e. map operation is non-blocking, the pointer to the mapped region returned by clEnqueueMapBuffer cannot be used until the map command has completed. The event argument returns an event object which can be used to query the execution status of the map command. When the map command is completed, the application can access the contents of the mapped region using the pointer returned by clEnqueueMapBuffer.
        /// </param>
        /// <param name="map_flags"> 
        /// Is a bit-field and can be set to MapRead to indicate that the region specified by (offset, cb) in the buffer object is being mapped for reading, and/or MapWrite to indicate that the region specified by (offset, cb) in the buffer object is being mapped for writing.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes and the size of the region in the buffer object that is being mapped.
        /// </param>
        /// <param name="cb"> 
        /// The offset in bytes and the size of the region in the buffer object that is being mapped.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used toquery or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static IntPtr EnqueueMapBuffer(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_map, OpenTK.Compute.CL10.MapFlags map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, ComputeEvent[] @event, [OutAttribute] Int32[] errcode_ret)
        {
            return CL.EnqueueMapBuffer(command_queue, buffer, blocking_map, map_flags, offset, cb, num_events_in_wait_list, event_wait_list, @event, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to map a region of the buffer object given by buffer into the host address space and returns a pointer to this mapped region.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="buffer"> 
        /// A valid buffer object. The OpenCL context associated with command_queue and buffer must be the same.
        /// </param>
        /// <param name="blocking_map"> 
        /// Indicates if the map operation is blocking or non-blocking.  If blocking_map is True, clEnqueueMapBuffer does not return until the specified region in buffer can be mapped.  If blocking_map is False i.e. map operation is non-blocking, the pointer to the mapped region returned by clEnqueueMapBuffer cannot be used until the map command has completed. The event argument returns an event object which can be used to query the execution status of the map command. When the map command is completed, the application can access the contents of the mapped region using the pointer returned by clEnqueueMapBuffer.
        /// </param>
        /// <param name="map_flags"> 
        /// Is a bit-field and can be set to MapRead to indicate that the region specified by (offset, cb) in the buffer object is being mapped for reading, and/or MapWrite to indicate that the region specified by (offset, cb) in the buffer object is being mapped for writing.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes and the size of the region in the buffer object that is being mapped.
        /// </param>
        /// <param name="cb"> 
        /// The offset in bytes and the size of the region in the buffer object that is being mapped.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used toquery or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static IntPtr EnqueueMapBuffer(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_map, OpenTK.Compute.CL10.MapFlags map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, ref ComputeEvent @event, [OutAttribute] out Int32 errcode_ret)
        {
            return CL.EnqueueMapBuffer(command_queue, buffer, blocking_map, map_flags, offset, cb, num_events_in_wait_list, ref event_wait_list, ref @event, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to map a region of the buffer object given by buffer into the host address space and returns a pointer to this mapped region.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="buffer"> 
        /// A valid buffer object. The OpenCL context associated with command_queue and buffer must be the same.
        /// </param>
        /// <param name="blocking_map"> 
        /// Indicates if the map operation is blocking or non-blocking.  If blocking_map is True, clEnqueueMapBuffer does not return until the specified region in buffer can be mapped.  If blocking_map is False i.e. map operation is non-blocking, the pointer to the mapped region returned by clEnqueueMapBuffer cannot be used until the map command has completed. The event argument returns an event object which can be used to query the execution status of the map command. When the map command is completed, the application can access the contents of the mapped region using the pointer returned by clEnqueueMapBuffer.
        /// </param>
        /// <param name="map_flags"> 
        /// Is a bit-field and can be set to MapRead to indicate that the region specified by (offset, cb) in the buffer object is being mapped for reading, and/or MapWrite to indicate that the region specified by (offset, cb) in the buffer object is being mapped for writing.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes and the size of the region in the buffer object that is being mapped.
        /// </param>
        /// <param name="cb"> 
        /// The offset in bytes and the size of the region in the buffer object that is being mapped.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used toquery or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe IntPtr EnqueueMapBuffer(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_map, OpenTK.Compute.CL10.MapFlags map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, ComputeEvent* @event, [OutAttribute] Int32* errcode_ret)
        {
            return CL.EnqueueMapBuffer(command_queue, buffer, blocking_map, map_flags, offset, cb, num_events_in_wait_list, event_wait_list, @event, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to map a region of an image object into the host address space and returns a pointer to this mapped region.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="image"> 
        /// A valid image object. The OpenCL context associated with command_queue and image must be the same.
        /// </param>
        /// <param name="blocking_map"> 
        /// Indicates if the map operation is blocking or non-blocking. If blocking_map is True, clEnqueueMapImage  does not return until the specified region in image can be mapped.  If blocking_map is False i.e. map operation is non-blocking, the pointer to the mapped region returned by clEnqueueMapImage cannot be used until the map command has completed. The event argument returns an event object which can be used to query the execution status of the map command. When the map command is completed, the application can access the contents of the mapped region using the pointer returned by clEnqueueMapImage.
        /// </param>
        /// <param name="map_flags"> 
        /// Is a bit-field and can be set to MapRead to indicate that the region specified by (origin, region) in the image object is being mapped for reading, and/or MapWrite to indicate that the region specified by (origin, region) in the image object is being mapped for writing.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Define the (x, y, z) offset in pixels and (width, height, depth) in pixels of the 2D or 3D rectangle region that is to be mapped. If image is a 2D image object, the z value given by origin[2] must be 0 and the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Define the (x, y, z) offset in pixels and (width, height, depth) in pixels of the 2D or 3D rectangle region that is to be mapped. If image is a 2D image object, the z value given by origin[2] must be 0 and the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// Returns the scan-line pitch in bytes for the mapped region. This must be a non-NULL value.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// Returns the size in bytes of each 2D slice for the mapped region. For a 2D image, zero is returned if this argument is not NULL. For a 3D image, image_slice_pitch must be a non-NULL value.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before clEnqueueMapImage can be executed. If event_wait_list is NULL, then clEnqueueMapImage does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid andnum_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before clEnqueueMapImage can be executed. If event_wait_list is NULL, then clEnqueueMapImage does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid andnum_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe IntPtr EnqueueMapImage(this CommandQueue command_queue, ComputeMemory image, bool blocking_map, OpenTK.Compute.CL10.MapFlags map_flags, IntPtr*[] origin, IntPtr*[] region, IntPtr[] image_row_pitch, IntPtr[] image_slice_pitch, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, ComputeEvent[] @event, [OutAttribute] Int32[] errcode_ret)
        {
            return CL.EnqueueMapImage(command_queue, image, blocking_map, map_flags, origin, region, image_row_pitch, image_slice_pitch, num_events_in_wait_list, event_wait_list, @event, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to map a region of an image object into the host address space and returns a pointer to this mapped region.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="image"> 
        /// A valid image object. The OpenCL context associated with command_queue and image must be the same.
        /// </param>
        /// <param name="blocking_map"> 
        /// Indicates if the map operation is blocking or non-blocking. If blocking_map is True, clEnqueueMapImage  does not return until the specified region in image can be mapped.  If blocking_map is False i.e. map operation is non-blocking, the pointer to the mapped region returned by clEnqueueMapImage cannot be used until the map command has completed. The event argument returns an event object which can be used to query the execution status of the map command. When the map command is completed, the application can access the contents of the mapped region using the pointer returned by clEnqueueMapImage.
        /// </param>
        /// <param name="map_flags"> 
        /// Is a bit-field and can be set to MapRead to indicate that the region specified by (origin, region) in the image object is being mapped for reading, and/or MapWrite to indicate that the region specified by (origin, region) in the image object is being mapped for writing.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Define the (x, y, z) offset in pixels and (width, height, depth) in pixels of the 2D or 3D rectangle region that is to be mapped. If image is a 2D image object, the z value given by origin[2] must be 0 and the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Define the (x, y, z) offset in pixels and (width, height, depth) in pixels of the 2D or 3D rectangle region that is to be mapped. If image is a 2D image object, the z value given by origin[2] must be 0 and the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// Returns the scan-line pitch in bytes for the mapped region. This must be a non-NULL value.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// Returns the size in bytes of each 2D slice for the mapped region. For a 2D image, zero is returned if this argument is not NULL. For a 3D image, image_slice_pitch must be a non-NULL value.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before clEnqueueMapImage can be executed. If event_wait_list is NULL, then clEnqueueMapImage does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid andnum_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before clEnqueueMapImage can be executed. If event_wait_list is NULL, then clEnqueueMapImage does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid andnum_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe IntPtr EnqueueMapImage(this CommandQueue command_queue, ComputeMemory image, bool blocking_map, OpenTK.Compute.CL10.MapFlags map_flags, ref IntPtr* origin, ref IntPtr* region, ref IntPtr image_row_pitch, ref IntPtr image_slice_pitch, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, ref ComputeEvent @event, [OutAttribute] out Int32 errcode_ret)
        {
            return CL.EnqueueMapImage(command_queue, image, blocking_map, map_flags, ref origin, ref region, ref image_row_pitch, ref image_slice_pitch, num_events_in_wait_list, ref event_wait_list, ref @event, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to map a region of an image object into the host address space and returns a pointer to this mapped region.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="image"> 
        /// A valid image object. The OpenCL context associated with command_queue and image must be the same.
        /// </param>
        /// <param name="blocking_map"> 
        /// Indicates if the map operation is blocking or non-blocking. If blocking_map is True, clEnqueueMapImage  does not return until the specified region in image can be mapped.  If blocking_map is False i.e. map operation is non-blocking, the pointer to the mapped region returned by clEnqueueMapImage cannot be used until the map command has completed. The event argument returns an event object which can be used to query the execution status of the map command. When the map command is completed, the application can access the contents of the mapped region using the pointer returned by clEnqueueMapImage.
        /// </param>
        /// <param name="map_flags"> 
        /// Is a bit-field and can be set to MapRead to indicate that the region specified by (origin, region) in the image object is being mapped for reading, and/or MapWrite to indicate that the region specified by (origin, region) in the image object is being mapped for writing.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Define the (x, y, z) offset in pixels and (width, height, depth) in pixels of the 2D or 3D rectangle region that is to be mapped. If image is a 2D image object, the z value given by origin[2] must be 0 and the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Define the (x, y, z) offset in pixels and (width, height, depth) in pixels of the 2D or 3D rectangle region that is to be mapped. If image is a 2D image object, the z value given by origin[2] must be 0 and the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// Returns the scan-line pitch in bytes for the mapped region. This must be a non-NULL value.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// Returns the size in bytes of each 2D slice for the mapped region. For a 2D image, zero is returned if this argument is not NULL. For a 3D image, image_slice_pitch must be a non-NULL value.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before clEnqueueMapImage can be executed. If event_wait_list is NULL, then clEnqueueMapImage does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid andnum_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before clEnqueueMapImage can be executed. If event_wait_list is NULL, then clEnqueueMapImage does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid andnum_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe IntPtr EnqueueMapImage(this CommandQueue command_queue, ComputeMemory image, bool blocking_map, OpenTK.Compute.CL10.MapFlags map_flags, IntPtr** origin, IntPtr** region, IntPtr* image_row_pitch, IntPtr* image_slice_pitch, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, ComputeEvent* @event, [OutAttribute] Int32* errcode_ret)
        {
            return CL.EnqueueMapImage(command_queue, image, blocking_map, map_flags, origin, region, image_row_pitch, image_slice_pitch, num_events_in_wait_list, event_wait_list, @event, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a marker command.
        /// </summary>
        /// <param name="command_queue"></param>
        /// <param name="@event"></param>
        [CLSCompliant(false)]
        public static Int32 EnqueueMarker(this CommandQueue command_queue, ComputeEvent[] @event)
        {
            return CL.EnqueueMarker(command_queue, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a marker command.
        /// </summary>
        /// <param name="command_queue"></param>
        /// <param name="@event"></param>
        [CLSCompliant(false)]
        public static Int32 EnqueueMarker(this CommandQueue command_queue, ref ComputeEvent @event)
        {
            return CL.EnqueueMarker(command_queue, ref @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a marker command.
        /// </summary>
        /// <param name="command_queue"></param>
        /// <param name="@event"></param>
        [CLSCompliant(false)]
        public static unsafe Int32 EnqueueMarker(this CommandQueue command_queue, ComputeEvent* @event)
        {
            return CL.EnqueueMarker(command_queue, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueNativeKernel(this CommandQueue command_queue, IntPtr user_func, IntPtr args, IntPtr cb_args, Int32 num_mem_objects, ComputeMemory[] mem_list, IntPtr args_mem_loc, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] ComputeEvent[] @event)
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, args, cb_args, num_mem_objects, mem_list, args_mem_loc, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueNativeKernel(this CommandQueue command_queue, IntPtr user_func, IntPtr args, IntPtr cb_args, Int32 num_mem_objects, ref ComputeMemory mem_list, IntPtr args_mem_loc, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, args, cb_args, num_mem_objects, ref mem_list, args_mem_loc, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueNativeKernel(this CommandQueue command_queue, IntPtr user_func, IntPtr args, IntPtr cb_args, Int32 num_mem_objects, ComputeMemory* mem_list, IntPtr args_mem_loc, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, args, cb_args, num_mem_objects, mem_list, args_mem_loc, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueNativeKernel<T2,T6>(this CommandQueue command_queue, IntPtr user_func, [InAttribute, OutAttribute] T2[] args, IntPtr cb_args, Int32 num_mem_objects, ComputeMemory[] mem_list, [InAttribute, OutAttribute] T6[] args_mem_loc, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] ComputeEvent[] @event)
            where T2 : struct
            where T6 : struct
        
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, args, cb_args, num_mem_objects, mem_list, args_mem_loc, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueNativeKernel<T2,T6>(this CommandQueue command_queue, IntPtr user_func, [InAttribute, OutAttribute] T2[] args, IntPtr cb_args, Int32 num_mem_objects, ref ComputeMemory mem_list, [InAttribute, OutAttribute] T6[] args_mem_loc, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T2 : struct
            where T6 : struct
        
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, args, cb_args, num_mem_objects, ref mem_list, args_mem_loc, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueNativeKernel<T2,T6>(this CommandQueue command_queue, IntPtr user_func, [InAttribute, OutAttribute] T2[] args, IntPtr cb_args, Int32 num_mem_objects, ComputeMemory* mem_list, [InAttribute, OutAttribute] T6[] args_mem_loc, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T2 : struct
            where T6 : struct
        
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, args, cb_args, num_mem_objects, mem_list, args_mem_loc, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueNativeKernel<T2,T6>(this CommandQueue command_queue, IntPtr user_func, [InAttribute, OutAttribute] T2[,] args, IntPtr cb_args, Int32 num_mem_objects, ComputeMemory[] mem_list, [InAttribute, OutAttribute] T6[,] args_mem_loc, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] ComputeEvent[] @event)
            where T2 : struct
            where T6 : struct
        
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, args, cb_args, num_mem_objects, mem_list, args_mem_loc, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueNativeKernel<T2,T6>(this CommandQueue command_queue, IntPtr user_func, [InAttribute, OutAttribute] T2[,] args, IntPtr cb_args, Int32 num_mem_objects, ref ComputeMemory mem_list, [InAttribute, OutAttribute] T6[,] args_mem_loc, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T2 : struct
            where T6 : struct
        
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, args, cb_args, num_mem_objects, ref mem_list, args_mem_loc, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueNativeKernel<T2,T6>(this CommandQueue command_queue, IntPtr user_func, [InAttribute, OutAttribute] T2[,] args, IntPtr cb_args, Int32 num_mem_objects, ComputeMemory* mem_list, [InAttribute, OutAttribute] T6[,] args_mem_loc, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T2 : struct
            where T6 : struct
        
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, args, cb_args, num_mem_objects, mem_list, args_mem_loc, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueNativeKernel<T2,T6>(this CommandQueue command_queue, IntPtr user_func, [InAttribute, OutAttribute] T2[,,] args, IntPtr cb_args, Int32 num_mem_objects, ComputeMemory[] mem_list, [InAttribute, OutAttribute] T6[,,] args_mem_loc, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] ComputeEvent[] @event)
            where T2 : struct
            where T6 : struct
        
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, args, cb_args, num_mem_objects, mem_list, args_mem_loc, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueNativeKernel<T2,T6>(this CommandQueue command_queue, IntPtr user_func, [InAttribute, OutAttribute] T2[,,] args, IntPtr cb_args, Int32 num_mem_objects, ref ComputeMemory mem_list, [InAttribute, OutAttribute] T6[,,] args_mem_loc, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T2 : struct
            where T6 : struct
        
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, args, cb_args, num_mem_objects, ref mem_list, args_mem_loc, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueNativeKernel<T2,T6>(this CommandQueue command_queue, IntPtr user_func, [InAttribute, OutAttribute] T2[,,] args, IntPtr cb_args, Int32 num_mem_objects, ComputeMemory* mem_list, [InAttribute, OutAttribute] T6[,,] args_mem_loc, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T2 : struct
            where T6 : struct
        
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, args, cb_args, num_mem_objects, mem_list, args_mem_loc, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueNativeKernel<T2,T6>(this CommandQueue command_queue, IntPtr user_func, [InAttribute, OutAttribute] ref T2 args, IntPtr cb_args, Int32 num_mem_objects, ComputeMemory[] mem_list, [InAttribute, OutAttribute] ref T6 args_mem_loc, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] ComputeEvent[] @event)
            where T2 : struct
            where T6 : struct
        
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, ref args, cb_args, num_mem_objects, mem_list, ref args_mem_loc, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueNativeKernel<T2,T6>(this CommandQueue command_queue, IntPtr user_func, [InAttribute, OutAttribute] ref T2 args, IntPtr cb_args, Int32 num_mem_objects, ref ComputeMemory mem_list, [InAttribute, OutAttribute] ref T6 args_mem_loc, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T2 : struct
            where T6 : struct
        
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, ref args, cb_args, num_mem_objects, ref mem_list, ref args_mem_loc, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a native C/C++ function not compiled using the OpenCL compiler.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. A native user function can only be executed on a command-queue created on a device that has CL_EXEC_NATIVE_KERNEL capability set in CL_DEVICE_EXECUTION_CAPABILITIES as specified in the table of OpenCL Device Queries for clGetDeviceInfo.
        /// </param>
        /// <param name="user_func"> 
        /// A pointer to a host-callable user function.
        /// </param>
        /// <param name="args"> 
        /// A pointer to the args list that user_func should be called with.
        /// </param>
        /// <param name="cb_args"> 
        /// The size in bytes of the args list that args points to.  The data pointed to by args and cb_args bytes in size will be copied and a pointer to this copied region will be passed to user_func. The copy needs to be done because the memory objects (ClMem values) that args may contain need to be modified and replaced by appropriate pointers to global memory. When clEnqueueNativeKernel returns, the memory region pointed to by args can be reused by the application.
        /// </param>
        /// <param name="num_mem_objects"> 
        /// The number of buffer objects that are passed in args.
        /// </param>
        /// <param name="mem_list"> 
        /// A list of valid buffer objects, if num_mem_objects is greater than 0. The buffer object values specified in mem_list are memory object handles (ClMem values) returned by clCreateBuffer or NULL.
        /// </param>
        /// <param name="args_mem_loc"> 
        /// A pointer to appropriate locations that args points to where memory object handles (ClMem values) are stored. Before the user function is executed, the memory object handles are replaced by pointers to global memory.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueNativeKernel<T2,T6>(this CommandQueue command_queue, IntPtr user_func, [InAttribute, OutAttribute] ref T2 args, IntPtr cb_args, Int32 num_mem_objects, ComputeMemory* mem_list, [InAttribute, OutAttribute] ref T6 args_mem_loc, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T2 : struct
            where T6 : struct
        
        {
            return CL.EnqueueNativeKernel(command_queue, user_func, ref args, cb_args, num_mem_objects, mem_list, ref args_mem_loc, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a kernel on a device.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. The kernel will be queued for execution on the device associated with command_queue.
        /// </param>
        /// <param name="kernel"> 
        /// A valid kernel object. The OpenCL context associated with kernel and command_queue must be the same.
        /// </param>
        /// <param name="work_dim"> 
        /// The number of dimensions used to specify the global work-items and work-items in the work-group. work_dim must be greater than zero and less than or equal to three.
        /// </param>
        /// <param name="global_work_offset"> 
        /// Must currently be a NULL value. In a future revision of OpenCL, global_work_offset can be used to specify an array of work_dim unsigned values that describe the offset used to calculate the global ID of a work-item instead of having the global IDs always start at offset (0, 0,... 0).
        /// </param>
        /// <param name="global_work_size"> 
        /// Points to an array of work_dim unsigned values that describe the number of global work-items in work_dim dimensions that will execute the kernel function. The total number of global work-items is computed as global_work_size[0] *...* global_work_size[work_dim - 1]. The values specified in global_work_size cannot exceed the range given by the Sizeof(sizeT) for the device on which the kernel execution will be enqueued. The Sizeof(sizeT) for a device can be determined using DeviceAddressBits in the table of OpenCL Device Queries for clGetDeviceInfo. If, for example, DeviceAddressBits = 32, i.e. the device uses a 32-bit address space, size_t is a 32-bit unsigned integer and global_work_size values must be in the range 1 .. 2^32 - 1. Values outside this range return a OutOfResources error.
        /// </param>
        /// <param name="local_work_size"> 
        /// Points to an array of work_dim unsigned values that describe the number of work-items that make up a work-group (also referred to as the size of the work-group) that will execute the kernel specified by kernel. The total number of work-items in a work-group is computed as local_work_size[0] *... * local_work_size[work_dim - 1]. The total number of work-items in the work-group must be less than or equal to the DeviceMaxWorkGroupSize value specified in table of OpenCL Device Queries for clGetDeviceInfo and the number of work-items specified in local_work_size[0],... local_work_size[work_dim - 1] must be less than or equal to the corresponding values specified by DeviceMaxWorkItemSizes[0],.... DeviceMaxWorkItemSizes[work_dim - 1]. The explicitly specified local_work_size will be used to determine how to break the global work-items specified by global_work_size into appropriate work-group instances. If local_work_size is specified, the values specified in global_work_size[0],... global_work_size[work_dim - 1] must be evenly divisable by the corresponding values specified in local_work_size[0],... local_work_size[work_dim - 1].The work-group size to be used for kernel can also be specified in the program source using the Attribute((reqdWorkGroupSize(x, y, z)))qualifier. In this case the size of work group specified by local_work_size must match the value specified by the ReqdWorkGroupSize__attribute__ qualifier.local_work_size can also be a NULL value in which case the OpenCL implementation will determine how to be break the global work-items into appropriate work-group instances.See note for more information.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueNDRangeKernel(this CommandQueue command_queue, ComputeKernel kernel, Int32 work_dim, IntPtr[] global_work_offset, IntPtr[] global_work_size, IntPtr[] local_work_size, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueNDRangeKernel(command_queue, kernel, work_dim, global_work_offset, global_work_size, local_work_size, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a kernel on a device.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. The kernel will be queued for execution on the device associated with command_queue.
        /// </param>
        /// <param name="kernel"> 
        /// A valid kernel object. The OpenCL context associated with kernel and command_queue must be the same.
        /// </param>
        /// <param name="work_dim"> 
        /// The number of dimensions used to specify the global work-items and work-items in the work-group. work_dim must be greater than zero and less than or equal to three.
        /// </param>
        /// <param name="global_work_offset"> 
        /// Must currently be a NULL value. In a future revision of OpenCL, global_work_offset can be used to specify an array of work_dim unsigned values that describe the offset used to calculate the global ID of a work-item instead of having the global IDs always start at offset (0, 0,... 0).
        /// </param>
        /// <param name="global_work_size"> 
        /// Points to an array of work_dim unsigned values that describe the number of global work-items in work_dim dimensions that will execute the kernel function. The total number of global work-items is computed as global_work_size[0] *...* global_work_size[work_dim - 1]. The values specified in global_work_size cannot exceed the range given by the Sizeof(sizeT) for the device on which the kernel execution will be enqueued. The Sizeof(sizeT) for a device can be determined using DeviceAddressBits in the table of OpenCL Device Queries for clGetDeviceInfo. If, for example, DeviceAddressBits = 32, i.e. the device uses a 32-bit address space, size_t is a 32-bit unsigned integer and global_work_size values must be in the range 1 .. 2^32 - 1. Values outside this range return a OutOfResources error.
        /// </param>
        /// <param name="local_work_size"> 
        /// Points to an array of work_dim unsigned values that describe the number of work-items that make up a work-group (also referred to as the size of the work-group) that will execute the kernel specified by kernel. The total number of work-items in a work-group is computed as local_work_size[0] *... * local_work_size[work_dim - 1]. The total number of work-items in the work-group must be less than or equal to the DeviceMaxWorkGroupSize value specified in table of OpenCL Device Queries for clGetDeviceInfo and the number of work-items specified in local_work_size[0],... local_work_size[work_dim - 1] must be less than or equal to the corresponding values specified by DeviceMaxWorkItemSizes[0],.... DeviceMaxWorkItemSizes[work_dim - 1]. The explicitly specified local_work_size will be used to determine how to break the global work-items specified by global_work_size into appropriate work-group instances. If local_work_size is specified, the values specified in global_work_size[0],... global_work_size[work_dim - 1] must be evenly divisable by the corresponding values specified in local_work_size[0],... local_work_size[work_dim - 1].The work-group size to be used for kernel can also be specified in the program source using the Attribute((reqdWorkGroupSize(x, y, z)))qualifier. In this case the size of work group specified by local_work_size must match the value specified by the ReqdWorkGroupSize__attribute__ qualifier.local_work_size can also be a NULL value in which case the OpenCL implementation will determine how to be break the global work-items into appropriate work-group instances.See note for more information.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueNDRangeKernel(this CommandQueue command_queue, ComputeKernel kernel, Int32 work_dim, ref IntPtr global_work_offset, ref IntPtr global_work_size, ref IntPtr local_work_size, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueNDRangeKernel(command_queue, kernel, work_dim, ref global_work_offset, ref global_work_size, ref local_work_size, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a kernel on a device.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. The kernel will be queued for execution on the device associated with command_queue.
        /// </param>
        /// <param name="kernel"> 
        /// A valid kernel object. The OpenCL context associated with kernel and command_queue must be the same.
        /// </param>
        /// <param name="work_dim"> 
        /// The number of dimensions used to specify the global work-items and work-items in the work-group. work_dim must be greater than zero and less than or equal to three.
        /// </param>
        /// <param name="global_work_offset"> 
        /// Must currently be a NULL value. In a future revision of OpenCL, global_work_offset can be used to specify an array of work_dim unsigned values that describe the offset used to calculate the global ID of a work-item instead of having the global IDs always start at offset (0, 0,... 0).
        /// </param>
        /// <param name="global_work_size"> 
        /// Points to an array of work_dim unsigned values that describe the number of global work-items in work_dim dimensions that will execute the kernel function. The total number of global work-items is computed as global_work_size[0] *...* global_work_size[work_dim - 1]. The values specified in global_work_size cannot exceed the range given by the Sizeof(sizeT) for the device on which the kernel execution will be enqueued. The Sizeof(sizeT) for a device can be determined using DeviceAddressBits in the table of OpenCL Device Queries for clGetDeviceInfo. If, for example, DeviceAddressBits = 32, i.e. the device uses a 32-bit address space, size_t is a 32-bit unsigned integer and global_work_size values must be in the range 1 .. 2^32 - 1. Values outside this range return a OutOfResources error.
        /// </param>
        /// <param name="local_work_size"> 
        /// Points to an array of work_dim unsigned values that describe the number of work-items that make up a work-group (also referred to as the size of the work-group) that will execute the kernel specified by kernel. The total number of work-items in a work-group is computed as local_work_size[0] *... * local_work_size[work_dim - 1]. The total number of work-items in the work-group must be less than or equal to the DeviceMaxWorkGroupSize value specified in table of OpenCL Device Queries for clGetDeviceInfo and the number of work-items specified in local_work_size[0],... local_work_size[work_dim - 1] must be less than or equal to the corresponding values specified by DeviceMaxWorkItemSizes[0],.... DeviceMaxWorkItemSizes[work_dim - 1]. The explicitly specified local_work_size will be used to determine how to break the global work-items specified by global_work_size into appropriate work-group instances. If local_work_size is specified, the values specified in global_work_size[0],... global_work_size[work_dim - 1] must be evenly divisable by the corresponding values specified in local_work_size[0],... local_work_size[work_dim - 1].The work-group size to be used for kernel can also be specified in the program source using the Attribute((reqdWorkGroupSize(x, y, z)))qualifier. In this case the size of work group specified by local_work_size must match the value specified by the ReqdWorkGroupSize__attribute__ qualifier.local_work_size can also be a NULL value in which case the OpenCL implementation will determine how to be break the global work-items into appropriate work-group instances.See note for more information.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueNDRangeKernel(this CommandQueue command_queue, ComputeKernel kernel, Int32 work_dim, IntPtr* global_work_offset, IntPtr* global_work_size, IntPtr* local_work_size, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
        {
            return CL.EnqueueNDRangeKernel(command_queue, kernel, work_dim, global_work_offset, global_work_size, local_work_size, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueReadBuffer(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueReadBuffer(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadBuffer(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueReadBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[] ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueReadBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[] ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[] ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T5 : struct
        
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueReadBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[,] ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueReadBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[,] ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[,] ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T5 : struct
        
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueReadBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[,,] ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueReadBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[,,] ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[,,] ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T5 : struct
        
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueReadBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] ref T5 ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ref ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueReadBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] ref T5 ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ref ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to read from a buffer object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking. If blocking_read is True i.e. the read command is blocking, clEnqueueReadBuffer does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. the read command is non-blocking, clEnqueueReadBuffer queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to read from.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being read.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be read into.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_read, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] ref T5 ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T5 : struct
        
        {
            return CL.EnqueueReadBuffer(command_queue, buffer, blocking_read, offset, cb, ref ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, IntPtr*[] origin, IntPtr*[] region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, origin, region, row_pitch, slice_pitch, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, IntPtr*[] origin, IntPtr*[] region, IntPtr row_pitch, IntPtr slice_pitch, [InAttribute, OutAttribute] T7[] ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, origin, region, row_pitch, slice_pitch, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, IntPtr*[] origin, IntPtr*[] region, IntPtr row_pitch, IntPtr slice_pitch, [InAttribute, OutAttribute] T7[,] ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, origin, region, row_pitch, slice_pitch, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, IntPtr*[] origin, IntPtr*[] region, IntPtr row_pitch, IntPtr slice_pitch, [InAttribute, OutAttribute] T7[,,] ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, origin, region, row_pitch, slice_pitch, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, IntPtr*[] origin, IntPtr*[] region, IntPtr row_pitch, IntPtr slice_pitch, [InAttribute, OutAttribute] ref T7 ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, origin, region, row_pitch, slice_pitch, ref ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, ref IntPtr* origin, ref IntPtr* region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, ref origin, ref region, row_pitch, slice_pitch, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, ref IntPtr* origin, ref IntPtr* region, IntPtr row_pitch, IntPtr slice_pitch, [InAttribute, OutAttribute] T7[] ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, ref origin, ref region, row_pitch, slice_pitch, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, ref IntPtr* origin, ref IntPtr* region, IntPtr row_pitch, IntPtr slice_pitch, [InAttribute, OutAttribute] T7[,] ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, ref origin, ref region, row_pitch, slice_pitch, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, ref IntPtr* origin, ref IntPtr* region, IntPtr row_pitch, IntPtr slice_pitch, [InAttribute, OutAttribute] T7[,,] ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, ref origin, ref region, row_pitch, slice_pitch, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, ref IntPtr* origin, ref IntPtr* region, IntPtr row_pitch, IntPtr slice_pitch, [InAttribute, OutAttribute] ref T7 ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, ref origin, ref region, row_pitch, slice_pitch, ref ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, IntPtr** origin, IntPtr** region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, origin, region, row_pitch, slice_pitch, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, IntPtr** origin, IntPtr** region, IntPtr row_pitch, IntPtr slice_pitch, [InAttribute, OutAttribute] T7[] ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T7 : struct
        
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, origin, region, row_pitch, slice_pitch, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, IntPtr** origin, IntPtr** region, IntPtr row_pitch, IntPtr slice_pitch, [InAttribute, OutAttribute] T7[,] ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T7 : struct
        
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, origin, region, row_pitch, slice_pitch, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, IntPtr** origin, IntPtr** region, IntPtr row_pitch, IntPtr slice_pitch, [InAttribute, OutAttribute] T7[,,] ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T7 : struct
        
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, origin, region, row_pitch, slice_pitch, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to read from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the read command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_read"> 
        /// Indicates if the read operations are blocking or non-blocking.  If blocking_read is True i.e. the read command is blocking, clEnqueueReadImage does not return until the buffer data has been read and copied into memory pointed to by ptr.  If blocking_read is False i.e. map operation is non-blocking, clEnqueueReadImage queues a non-blocking read command and returns. The contents of the buffer that ptr points to cannot be used until the read command has completed. The event argument returns an event object which can be used to query the execution status of the read command. When the read command has completed, the contents of the buffer that ptr points to can be used by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to read. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being read. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being read. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be read from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular read command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueReadImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_read, IntPtr** origin, IntPtr** region, IntPtr row_pitch, IntPtr slice_pitch, [InAttribute, OutAttribute] ref T7 ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T7 : struct
        
        {
            return CL.EnqueueReadImage(command_queue, image, blocking_read, origin, region, row_pitch, slice_pitch, ref ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a kernel on a device.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. The kernel will be queued for execution on the device associated with command_queue.
        /// </param>
        /// <param name="kernel"> 
        /// A valid kernel object. The OpenCL context associated with kernel and command_queue must be the same.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static Int32 EnqueueTask(this CommandQueue command_queue, ComputeKernel kernel, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, ComputeEvent[] @event)
        {
            return CL.EnqueueTask(command_queue, kernel, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a kernel on a device.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. The kernel will be queued for execution on the device associated with command_queue.
        /// </param>
        /// <param name="kernel"> 
        /// A valid kernel object. The OpenCL context associated with kernel and command_queue must be the same.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static Int32 EnqueueTask(this CommandQueue command_queue, ComputeKernel kernel, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, ref ComputeEvent @event)
        {
            return CL.EnqueueTask(command_queue, kernel, num_events_in_wait_list, ref event_wait_list, ref @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to execute a kernel on a device.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue. The kernel will be queued for execution on the device associated with command_queue.
        /// </param>
        /// <param name="kernel"> 
        /// A valid kernel object. The OpenCL context associated with kernel and command_queue must be the same.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular kernel execution instance. Event objects are unique and can be used to identify a particular kernel execution instance later on. If event is NULL, no event will be created for this kernel execution instance and therefore it will not be possible for the application to query or queue a wait for this particular kernel execution instance.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe Int32 EnqueueTask(this CommandQueue command_queue, ComputeKernel kernel, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, ComputeEvent* @event)
        {
            return CL.EnqueueTask(command_queue, kernel, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueUnmapMemObject(this CommandQueue command_queue, ComputeMemory memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, mapped_ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueUnmapMemObject(this CommandQueue command_queue, ComputeMemory memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, mapped_ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueUnmapMemObject(this CommandQueue command_queue, ComputeMemory memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, mapped_ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueUnmapMemObject<T2>(this CommandQueue command_queue, ComputeMemory memobj, [InAttribute, OutAttribute] T2[] mapped_ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T2 : struct
        
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, mapped_ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueUnmapMemObject<T2>(this CommandQueue command_queue, ComputeMemory memobj, [InAttribute, OutAttribute] T2[] mapped_ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T2 : struct
        
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, mapped_ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueUnmapMemObject<T2>(this CommandQueue command_queue, ComputeMemory memobj, [InAttribute, OutAttribute] T2[] mapped_ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T2 : struct
        
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, mapped_ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueUnmapMemObject<T2>(this CommandQueue command_queue, ComputeMemory memobj, [InAttribute, OutAttribute] T2[,] mapped_ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T2 : struct
        
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, mapped_ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueUnmapMemObject<T2>(this CommandQueue command_queue, ComputeMemory memobj, [InAttribute, OutAttribute] T2[,] mapped_ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T2 : struct
        
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, mapped_ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueUnmapMemObject<T2>(this CommandQueue command_queue, ComputeMemory memobj, [InAttribute, OutAttribute] T2[,] mapped_ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T2 : struct
        
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, mapped_ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueUnmapMemObject<T2>(this CommandQueue command_queue, ComputeMemory memobj, [InAttribute, OutAttribute] T2[,,] mapped_ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T2 : struct
        
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, mapped_ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueUnmapMemObject<T2>(this CommandQueue command_queue, ComputeMemory memobj, [InAttribute, OutAttribute] T2[,,] mapped_ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T2 : struct
        
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, mapped_ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueUnmapMemObject<T2>(this CommandQueue command_queue, ComputeMemory memobj, [InAttribute, OutAttribute] T2[,,] mapped_ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T2 : struct
        
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, mapped_ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueUnmapMemObject<T2>(this CommandQueue command_queue, ComputeMemory memobj, [InAttribute, OutAttribute] ref T2 mapped_ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T2 : struct
        
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, ref mapped_ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueUnmapMemObject<T2>(this CommandQueue command_queue, ComputeMemory memobj, [InAttribute, OutAttribute] ref T2 mapped_ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T2 : struct
        
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, ref mapped_ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to unmap a previously mapped region of a memory object.
        /// </summary>
        /// <param name="command_queue"> 
        /// Must be a valid command-queue.
        /// </param>
        /// <param name="memobj"> 
        /// A valid memory object. The OpenCL context associated with command_queue and memobj must be the same.
        /// </param>
        /// <param name="mapped_ptr"> 
        /// The host address returned by a previous call to clEnqueueMapBuffer or clEnqueueMapImage for memobj.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before  clEnqueueUnmapMemObject can be executed. If  event_wait_list is NULL, then clEnqueueUnmapMemObject does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular copy command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete. clEnqueueBarrier can be used instead.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueUnmapMemObject<T2>(this CommandQueue command_queue, ComputeMemory memobj, [InAttribute, OutAttribute] ref T2 mapped_ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T2 : struct
        
        {
            return CL.EnqueueUnmapMemObject(command_queue, memobj, ref mapped_ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a wait for a specific event or a list of events to complete before any future commands queued in the command-queue are executed.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue.
        /// </param>
        /// <param name="num_events"> 
        /// Specifies the number of events given by event_list.
        /// </param>
        /// <param name="event_list"> 
        /// Events specified in event_list act as synchronization points. Each event in event_list must be a valid event object returned by a previous call to the following: clEnqueueNDRangeKernelclEnqueueTaskclEnqueueNativeKernelclEnqueueReadBuffer, clEnqueueWriteBuffer,  clEnqueueMapBuffer, clEnqueueReadImage, clEnqueueWriteImage,  clEnqueueMapImageclEnqueueCopyBuffer, clEnqueueCopyImageclEnqueueCopyBufferToImageclEnqueueCopyImageToBufferclEnqueueMarker
        /// </param>
        [CLSCompliant(false)]
        public static Int32 EnqueueWaitForEvents(this CommandQueue command_queue, Int32 num_events, ComputeEvent[] event_list)
        {
            return CL.EnqueueWaitForEvents(command_queue, num_events, event_list);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a wait for a specific event or a list of events to complete before any future commands queued in the command-queue are executed.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue.
        /// </param>
        /// <param name="num_events"> 
        /// Specifies the number of events given by event_list.
        /// </param>
        /// <param name="event_list"> 
        /// Events specified in event_list act as synchronization points. Each event in event_list must be a valid event object returned by a previous call to the following: clEnqueueNDRangeKernelclEnqueueTaskclEnqueueNativeKernelclEnqueueReadBuffer, clEnqueueWriteBuffer,  clEnqueueMapBuffer, clEnqueueReadImage, clEnqueueWriteImage,  clEnqueueMapImageclEnqueueCopyBuffer, clEnqueueCopyImageclEnqueueCopyBufferToImageclEnqueueCopyImageToBufferclEnqueueMarker
        /// </param>
        [CLSCompliant(false)]
        public static Int32 EnqueueWaitForEvents(this CommandQueue command_queue, Int32 num_events, ref ComputeEvent event_list)
        {
            return CL.EnqueueWaitForEvents(command_queue, num_events, ref event_list);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a wait for a specific event or a list of events to complete before any future commands queued in the command-queue are executed.
        /// </summary>
        /// <param name="command_queue"> 
        /// A valid command-queue.
        /// </param>
        /// <param name="num_events"> 
        /// Specifies the number of events given by event_list.
        /// </param>
        /// <param name="event_list"> 
        /// Events specified in event_list act as synchronization points. Each event in event_list must be a valid event object returned by a previous call to the following: clEnqueueNDRangeKernelclEnqueueTaskclEnqueueNativeKernelclEnqueueReadBuffer, clEnqueueWriteBuffer,  clEnqueueMapBuffer, clEnqueueReadImage, clEnqueueWriteImage,  clEnqueueMapImageclEnqueueCopyBuffer, clEnqueueCopyImageclEnqueueCopyBufferToImageclEnqueueCopyImageToBufferclEnqueueMarker
        /// </param>
        [CLSCompliant(false)]
        public static unsafe Int32 EnqueueWaitForEvents(this CommandQueue command_queue, Int32 num_events, ComputeEvent* event_list)
        {
            return CL.EnqueueWaitForEvents(command_queue, num_events, event_list);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueWriteBuffer(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueWriteBuffer(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteBuffer(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueWriteBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[] ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueWriteBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[] ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[] ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T5 : struct
        
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueWriteBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[,] ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueWriteBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[,] ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[,] ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T5 : struct
        
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueWriteBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[,,] ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueWriteBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[,,] ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] T5[,,] ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T5 : struct
        
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueWriteBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] ref T5 ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ref ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode EnqueueWriteBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] ref T5 ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T5 : struct
        
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ref ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueue commands to write to a buffer object from host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and buffer must be created with the same OpenCL context.
        /// </param>
        /// <param name="buffer"> 
        /// Refers to a valid buffer object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operations are blocking or nonblocking.  If blocking_write is True, the OpenCL implementation copies the data referred to by ptr and enqueues the write operation in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteBuffer call returns.  If blocking_write is False, the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="offset"> 
        /// The offset in bytes in the buffer object to write to.
        /// </param>
        /// <param name="cb"> 
        /// The size in bytes of data being written.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to buffer in host memory where data is to be written from.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// event_wait_list and num_events_in_wait_list specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteBuffer<T5>(this CommandQueue command_queue, ComputeMemory buffer, bool blocking_write, IntPtr offset, IntPtr cb, [InAttribute, OutAttribute] ref T5 ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T5 : struct
        
        {
            return CL.EnqueueWriteBuffer(command_queue, buffer, blocking_write, offset, cb, ref ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, IntPtr*[] origin, IntPtr*[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, origin, region, input_row_pitch, input_slice_pitch, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, IntPtr*[] origin, IntPtr*[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, [InAttribute, OutAttribute] T7[] ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, origin, region, input_row_pitch, input_slice_pitch, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, IntPtr*[] origin, IntPtr*[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, [InAttribute, OutAttribute] T7[,] ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, origin, region, input_row_pitch, input_slice_pitch, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, IntPtr*[] origin, IntPtr*[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, [InAttribute, OutAttribute] T7[,,] ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, origin, region, input_row_pitch, input_slice_pitch, ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, IntPtr*[] origin, IntPtr*[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, [InAttribute, OutAttribute] ref T7 ptr, Int32 num_events_in_wait_list, ComputeEvent[] event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, origin, region, input_row_pitch, input_slice_pitch, ref ptr, num_events_in_wait_list, event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, ref IntPtr* origin, ref IntPtr* region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, ref origin, ref region, input_row_pitch, input_slice_pitch, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, ref IntPtr* origin, ref IntPtr* region, IntPtr input_row_pitch, IntPtr input_slice_pitch, [InAttribute, OutAttribute] T7[] ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, ref origin, ref region, input_row_pitch, input_slice_pitch, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, ref IntPtr* origin, ref IntPtr* region, IntPtr input_row_pitch, IntPtr input_slice_pitch, [InAttribute, OutAttribute] T7[,] ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, ref origin, ref region, input_row_pitch, input_slice_pitch, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, ref IntPtr* origin, ref IntPtr* region, IntPtr input_row_pitch, IntPtr input_slice_pitch, [InAttribute, OutAttribute] T7[,,] ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, ref origin, ref region, input_row_pitch, input_slice_pitch, ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, ref IntPtr* origin, ref IntPtr* region, IntPtr input_row_pitch, IntPtr input_slice_pitch, [InAttribute, OutAttribute] ref T7 ptr, Int32 num_events_in_wait_list, ref ComputeEvent event_wait_list, [OutAttribute] out ComputeEvent @event)
            where T7 : struct
        
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, ref origin, ref region, input_row_pitch, input_slice_pitch, ref ptr, num_events_in_wait_list, ref event_wait_list, out @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, IntPtr** origin, IntPtr** region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, origin, region, input_row_pitch, input_slice_pitch, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, IntPtr** origin, IntPtr** region, IntPtr input_row_pitch, IntPtr input_slice_pitch, [InAttribute, OutAttribute] T7[] ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T7 : struct
        
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, origin, region, input_row_pitch, input_slice_pitch, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, IntPtr** origin, IntPtr** region, IntPtr input_row_pitch, IntPtr input_slice_pitch, [InAttribute, OutAttribute] T7[,] ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T7 : struct
        
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, origin, region, input_row_pitch, input_slice_pitch, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, IntPtr** origin, IntPtr** region, IntPtr input_row_pitch, IntPtr input_slice_pitch, [InAttribute, OutAttribute] T7[,,] ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T7 : struct
        
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, origin, region, input_row_pitch, input_slice_pitch, ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Enqueues a command to write from a 2D or 3D image object to host memory.
        /// </summary>
        /// <param name="command_queue"> 
        /// Refers to the command-queue in which the write command will be queued. command_queue and image must be created with the same OpenCL contex
        /// </param>
        /// <param name="image"> 
        /// Refers to a valid 2D or 3D image object.
        /// </param>
        /// <param name="blocking_write"> 
        /// Indicates if the write operation is blocking or non-blocking.  If blocking_write is True the OpenCL implementation copies the data referred to by ptr and enqueues the write command in the command-queue. The memory pointed to by ptr can be reused by the application after the clEnqueueWriteImage call returns.  If blocking_write is False the OpenCL implementation will use ptr to perform a nonblocking write. As the write is non-blocking the implementation can return immediately. The memory pointed to by ptr cannot be reused by the application after the call returns. The event argument returns an event object which can be used to query the execution status of the write command. When the write command has completed, the memory pointed to by ptr can then be reused by the application.
        /// </param>
        /// <param name="origin">[length: 3] 
        /// Defines the (x, y, z) offset in pixels in the image from where to write or write. If image is a 2D image object, the z value given by origin[2] must be 0.
        /// </param>
        /// <param name="region">[length: 3] 
        /// Defines the (width, height, depth) in pixels of the 2D or 3D rectangle being write or written. If image is a 2D image object, the depth value given by region[2] must be 1.
        /// </param>
        /// <param name="input_row_pitch"> 
        /// The length of each row in bytes. This value must be greater than or equal to the element size in bytes * width. If input_row_pitch is set to 0, the appropriate row pitch is calculated based on the size of each element in bytes multiplied by width.
        /// </param>
        /// <param name="input_slice_pitch"> 
        /// Size in bytes of the 2D slice of the 3D region of a 3D image being written. This must be 0 if image is a 2D image. This value must be greater than or equal to row_pitch * height. If input_slice_pitch is set to 0, the appropriate slice pitch is calculated based on the row_pitch * height.
        /// </param>
        /// <param name="ptr"> 
        /// The pointer to a buffer in host memory where image data is to be written to.
        /// </param>
        /// <param name="num_events_in_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event_wait_list"> 
        /// Specify events that need to complete before this particular command can be executed. If event_wait_list is NULL, then this particular command does not wait on any event to complete. If event_wait_list is NULL, num_events_in_wait_list must be 0. If event_wait_list is not NULL, the list of events pointed to by event_wait_list must be valid and num_events_in_wait_list must be greater than 0. The events specified in event_wait_list act as synchronization points. The context associated with events in event_wait_list and command_queue must be the same.
        /// </param>
        /// <param name="event"> 
        /// Returns an event object that identifies this particular write command and can be used to query or queue a wait for this particular command to complete. event can be NULL in which case it will not be possible for the application to query the status of this command or queue a wait for this command to complete.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode EnqueueWriteImage<T7>(this CommandQueue command_queue, ComputeMemory image, bool blocking_write, IntPtr** origin, IntPtr** region, IntPtr input_row_pitch, IntPtr input_slice_pitch, [InAttribute, OutAttribute] ref T7 ptr, Int32 num_events_in_wait_list, ComputeEvent* event_wait_list, [OutAttribute] ComputeEvent* @event)
            where T7 : struct
        
        {
            return CL.EnqueueWriteImage(command_queue, image, blocking_write, origin, region, input_row_pitch, input_slice_pitch, ref ptr, num_events_in_wait_list, event_wait_list, @event);
        }

        /// <summary>[requires: v1.0]
        /// Blocks until all previously queued OpenCL commands in a command-queue are issued to the associated device and have completed.
        /// </summary>
        /// <param name="command_queue"></param>
        public static ErrorCode Finish(this CommandQueue command_queue)
        {
            return CL.Finish(command_queue);
        }

        /// <summary>[requires: v1.0]
        /// Issues all previously queued OpenCL commands in a command-queue to the device associated with the command-queue.
        /// </summary>
        /// <param name="command_queue"></param>
        public static ErrorCode Flush(this CommandQueue command_queue)
        {
            return CL.Flush(command_queue);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetCommandQueueInfo(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] IntPtr[] param_value_size_ret)
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetCommandQueueInfo(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] out IntPtr param_value_size_ret)
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetCommandQueueInfo(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] IntPtr* param_value_size_ret)
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetCommandQueueInfo<T3>(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetCommandQueueInfo<T3>(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetCommandQueueInfo<T3>(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetCommandQueueInfo<T3>(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetCommandQueueInfo<T3>(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetCommandQueueInfo<T3>(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetCommandQueueInfo<T3>(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetCommandQueueInfo<T3>(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetCommandQueueInfo<T3>(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetCommandQueueInfo<T3>(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, ref param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetCommandQueueInfo<T3>(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, ref param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table below. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetCommandQueueInfo<T3>(this CommandQueue command_queue, OpenTK.Compute.CL10.CommandQueueInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetCommandQueueInfo(command_queue, param_name, param_value_size, ref param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Decrements the command_queue reference count.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue to release.
        /// </param>
        public static ErrorCode ReleaseCommandQueue(this CommandQueue command_queue)
        {
            return CL.ReleaseCommandQueue(command_queue);
        }

        /// <summary>[requires: v1.0]
        /// Increments the command_queue reference count.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue to retain.
        /// </param>
        public static ErrorCode RetainCommandQueue(this CommandQueue command_queue)
        {
            return CL.RetainCommandQueue(command_queue);
        }

        /// <summary>[requires: v1.0]
        /// Enable or disable the properties of a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="properties"> 
        /// Specifies the new command-queue properties to be applied to command_queue. Only command-queue properties specified for clCreateCommandQueue can be set in properties; otherwise the value specified in properties is considered to be not valid.
        /// </param>
        /// <param name="enable"> 
        /// Determines whether the values specified by properties are enabled (if enable is True) or disabled (if enable is False) for the command-queue. The allowed property values are the same as those specified for clCreateCommandQueue.
        /// </param>
        /// <param name="old_properties"> 
        /// Returns the command-queue properties before they were changed by clSetCommandQueueProperty. If old_properties is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static Int32 SetCommandQueueProperty(this CommandQueue command_queue, CommandQueueFlags properties, bool enable, CommandQueueFlags[] old_properties)
        {
            return CL.SetCommandQueueProperty(command_queue, properties, enable, old_properties);
        }

        /// <summary>[requires: v1.0]
        /// Enable or disable the properties of a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="properties"> 
        /// Specifies the new command-queue properties to be applied to command_queue. Only command-queue properties specified for clCreateCommandQueue can be set in properties; otherwise the value specified in properties is considered to be not valid.
        /// </param>
        /// <param name="enable"> 
        /// Determines whether the values specified by properties are enabled (if enable is True) or disabled (if enable is False) for the command-queue. The allowed property values are the same as those specified for clCreateCommandQueue.
        /// </param>
        /// <param name="old_properties"> 
        /// Returns the command-queue properties before they were changed by clSetCommandQueueProperty. If old_properties is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static Int32 SetCommandQueueProperty(this CommandQueue command_queue, CommandQueueFlags properties, bool enable, ref CommandQueueFlags old_properties)
        {
            return CL.SetCommandQueueProperty(command_queue, properties, enable, ref old_properties);
        }

        /// <summary>[requires: v1.0]
        /// Enable or disable the properties of a command-queue.
        /// </summary>
        /// <param name="command_queue"> 
        /// Specifies the command-queue being queried.
        /// </param>
        /// <param name="properties"> 
        /// Specifies the new command-queue properties to be applied to command_queue. Only command-queue properties specified for clCreateCommandQueue can be set in properties; otherwise the value specified in properties is considered to be not valid.
        /// </param>
        /// <param name="enable"> 
        /// Determines whether the values specified by properties are enabled (if enable is True) or disabled (if enable is False) for the command-queue. The allowed property values are the same as those specified for clCreateCommandQueue.
        /// </param>
        /// <param name="old_properties"> 
        /// Returns the command-queue properties before they were changed by clSetCommandQueueProperty. If old_properties is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe Int32 SetCommandQueueProperty(this CommandQueue command_queue, CommandQueueFlags properties, bool enable, CommandQueueFlags* old_properties)
        {
            return CL.SetCommandQueueProperty(command_queue, properties, enable, old_properties);
        }

    }

    /// <summary>
    /// Defines methods to simplify ComputeContext usage.
    /// </summary>
    public partial struct ComputeContext : IComparable<ComputeContext>, IEquatable<ComputeContext>
    {
        internal IntPtr Value;

        #region IComparable<ComputeContext> Implementation

        /// <summary>
        /// Returns the sort order of the current instance compared to the specified <see cref="ComputeContext"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputeContext"/> to compare with the current <see cref="ComputeContext"/>.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        public int CompareTo(ComputeContext other)
        {
            int result = 0;
            if (result == 0)
                result = Value.CompareTo(other.Value);
            return result;
        }

        #endregion

        #region IEquatable<ComputeContext> Implementation

        /// <summary>
        /// Determines whether the specified <see cref="ComputeContext"/> is equal to the current <see cref="ComputeContext"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputeContext"/> to compare with the current <see cref="ComputeContext"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputeContext"/> is equal to the current
        /// <see cref="ComputeContext"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(ComputeContext other)
        {
            bool result = true;
            result &= Value.Equals(other.Value);
            return result;
        }

        #endregion

        #region Public Members

        /// <summary>Defines a zero (or null) <see cref="ComputeContext"/></summary>
        public static readonly ComputeContext Zero = new ComputeContext();

        /// <summary>Tests two <see cref="ComputeContext"/> instances for equality.</summary>
        public static bool operator ==(ComputeContext left, ComputeContext right)
        {
            return left.Equals(right);
        }

        /// <summary>Tests two <see cref="ComputeContext"/> instances for inequality.</summary>
        public static bool operator !=(ComputeContext left, ComputeContext right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="ComputeContext"/>.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with the current <see cref="ComputeContext"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputeContext"/> is equal to the current
        /// <see cref="ComputeContext"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object other)
        {
            return other is ComputeContext && Equals((ComputeContext)other);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="ComputeContext"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= Value.GetHashCode();
            return hash;
        }

        /// <summary>[requires: v1.0]
        /// Creates an OpenCL context.
        /// </summary>
        /// <param name="properties"> 
        /// Specifies a list of context property names and their corresponding values. Each property name is immediately followed by the corresponding desired value. The list is terminated with 0. properties can be NULL in which case the platform that is selected is implementation-defined. The list of supported properties is described in the table below. cl_context_properties enumProperty valueDescriptionContextPlatformcl_platform_idSpecifies the platform to use.
        /// </param>
        /// <param name="num_devices"> 
        /// The number of devices specified in the devices argument.
        /// </param>
        /// <param name="devices"> 
        /// A pointer to a list of unique devices returned by clGetDeviceIDs for a platform.
        /// </param>
        /// <param name="pfn_notify"> 
        /// A callback function that can be registered by the application. This callback function will be used by the OpenCL implementation to report information on errors that occur in this context. This callback function may be called asynchronously by the OpenCL implementation. It is the application's responsibility to ensure that the callback function is thread-safe. If pfn_notify is NULL, no callback function is registered. The parameters to this callback function are: errinfo is a pointer to an error string.private_info and cb represent a pointer to binary data that is returned by the OpenCL implementation that can be used to log additional information helpful in debugging the error.user_data is a pointer to user supplied data.
        /// </param>
        /// <param name="user_data"> 
        /// Passed as the user_data argument when pfn_notify is called. user_data can be NULL.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeContext CreateContext(IntPtr[] properties, Int32 num_devices, ComputeDevice[] devices, ContextNotifyDelegate pfn_notify, IntPtr user_data, [OutAttribute] out ErrorCode errcode_ret)
        {
            return CL.CreateContext(properties, num_devices, devices, pfn_notify, user_data, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates an OpenCL context.
        /// </summary>
        /// <param name="properties"> 
        /// Specifies a list of context property names and their corresponding values. Each property name is immediately followed by the corresponding desired value. The list is terminated with 0. properties can be NULL in which case the platform that is selected is implementation-defined. The list of supported properties is described in the table below. cl_context_properties enumProperty valueDescriptionContextPlatformcl_platform_idSpecifies the platform to use.
        /// </param>
        /// <param name="num_devices"> 
        /// The number of devices specified in the devices argument.
        /// </param>
        /// <param name="devices"> 
        /// A pointer to a list of unique devices returned by clGetDeviceIDs for a platform.
        /// </param>
        /// <param name="pfn_notify"> 
        /// A callback function that can be registered by the application. This callback function will be used by the OpenCL implementation to report information on errors that occur in this context. This callback function may be called asynchronously by the OpenCL implementation. It is the application's responsibility to ensure that the callback function is thread-safe. If pfn_notify is NULL, no callback function is registered. The parameters to this callback function are: errinfo is a pointer to an error string.private_info and cb represent a pointer to binary data that is returned by the OpenCL implementation that can be used to log additional information helpful in debugging the error.user_data is a pointer to user supplied data.
        /// </param>
        /// <param name="user_data"> 
        /// Passed as the user_data argument when pfn_notify is called. user_data can be NULL.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeContext CreateContext(ref IntPtr properties, Int32 num_devices, ref ComputeDevice devices, ContextNotifyDelegate pfn_notify, IntPtr user_data, [OutAttribute] out ErrorCode errcode_ret)
        {
            return CL.CreateContext(ref properties, num_devices, ref devices, pfn_notify, user_data, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates an OpenCL context.
        /// </summary>
        /// <param name="properties"> 
        /// Specifies a list of context property names and their corresponding values. Each property name is immediately followed by the corresponding desired value. The list is terminated with 0. properties can be NULL in which case the platform that is selected is implementation-defined. The list of supported properties is described in the table below. cl_context_properties enumProperty valueDescriptionContextPlatformcl_platform_idSpecifies the platform to use.
        /// </param>
        /// <param name="num_devices"> 
        /// The number of devices specified in the devices argument.
        /// </param>
        /// <param name="devices"> 
        /// A pointer to a list of unique devices returned by clGetDeviceIDs for a platform.
        /// </param>
        /// <param name="pfn_notify"> 
        /// A callback function that can be registered by the application. This callback function will be used by the OpenCL implementation to report information on errors that occur in this context. This callback function may be called asynchronously by the OpenCL implementation. It is the application's responsibility to ensure that the callback function is thread-safe. If pfn_notify is NULL, no callback function is registered. The parameters to this callback function are: errinfo is a pointer to an error string.private_info and cb represent a pointer to binary data that is returned by the OpenCL implementation that can be used to log additional information helpful in debugging the error.user_data is a pointer to user supplied data.
        /// </param>
        /// <param name="user_data"> 
        /// Passed as the user_data argument when pfn_notify is called. user_data can be NULL.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeContext CreateContext(IntPtr* properties, Int32 num_devices, ComputeDevice* devices, ContextNotifyDelegate pfn_notify, IntPtr user_data, [OutAttribute] ErrorCode* errcode_ret)
        {
            return CL.CreateContext(properties, num_devices, devices, pfn_notify, user_data, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Create an OpenCL context from a device type that identifies the specific device(s) to use.
        /// </summary>
        /// <param name="properties"> 
        /// Specifies a list of context property names and their corresponding values. Each property name is immediately followed by the corresponding desired value. The list is terminated with 0. properties can be NULL in which case the platform that is selected is implementation-defined. The list of supported properties is described in the table below. cl_context_properties enumProperty valueDescriptionContextPlatformcl_platform_idSpecifies the platform to use.
        /// </param>
        /// <param name="device_type"> 
        /// A bit-field that identifies the type of device and is described in the table below. cl_device_typeDescriptionDeviceTypeCpuAn OpenCL device that is the host processor. The host processor runs the OpenCL implementations and is a single or multi-core CPU.DeviceTypeGpuAn OpenCL device that is a GPU. By this we mean that the device can also be used to accelerate a 3D API such as OpenGL or DirectX.DeviceTypeAcceleratorDedicated OpenCL accelerators (for example the IBM CELL Blade). These devices communicate with the host processor using a peripheral interconnect such as PCIe.DeviceTypeDefaultThe default OpenCL device in the system.DeviceTypeAllAll OpenCL devices available in the system.
        /// </param>
        /// <param name="pfn_notify"> 
        /// A callback function that can be registered by the application. This callback function will be used by the OpenCL implementation to report information on errors that occur in this context. This callback function may be called asynchronously by the OpenCL implementation. It is the application's responsibility to ensure that the callback function is thread-safe. If pfn_notify is NULL, no callback function is registered. The parameters to this callback function are: errinfo is a pointer to an error string.private_info and cb represent a pointer to binary data that is returned by the OpenCL implementation that can be used to log additional information helpful in debugging the error.user_data is a pointer to user supplied data.
        /// </param>
        /// <param name="user_data"> 
        /// Passed as the user_data argument when pfn_notify is called. user_data can be NULL.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeContext CreateContextFromType(IntPtr[] properties, DeviceTypeFlags device_type, ContextNotifyDelegate pfn_notify, IntPtr user_data, [OutAttribute] out ErrorCode errcode_ret)
        {
            return CL.CreateContextFromType(properties, device_type, pfn_notify, user_data, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Create an OpenCL context from a device type that identifies the specific device(s) to use.
        /// </summary>
        /// <param name="properties"> 
        /// Specifies a list of context property names and their corresponding values. Each property name is immediately followed by the corresponding desired value. The list is terminated with 0. properties can be NULL in which case the platform that is selected is implementation-defined. The list of supported properties is described in the table below. cl_context_properties enumProperty valueDescriptionContextPlatformcl_platform_idSpecifies the platform to use.
        /// </param>
        /// <param name="device_type"> 
        /// A bit-field that identifies the type of device and is described in the table below. cl_device_typeDescriptionDeviceTypeCpuAn OpenCL device that is the host processor. The host processor runs the OpenCL implementations and is a single or multi-core CPU.DeviceTypeGpuAn OpenCL device that is a GPU. By this we mean that the device can also be used to accelerate a 3D API such as OpenGL or DirectX.DeviceTypeAcceleratorDedicated OpenCL accelerators (for example the IBM CELL Blade). These devices communicate with the host processor using a peripheral interconnect such as PCIe.DeviceTypeDefaultThe default OpenCL device in the system.DeviceTypeAllAll OpenCL devices available in the system.
        /// </param>
        /// <param name="pfn_notify"> 
        /// A callback function that can be registered by the application. This callback function will be used by the OpenCL implementation to report information on errors that occur in this context. This callback function may be called asynchronously by the OpenCL implementation. It is the application's responsibility to ensure that the callback function is thread-safe. If pfn_notify is NULL, no callback function is registered. The parameters to this callback function are: errinfo is a pointer to an error string.private_info and cb represent a pointer to binary data that is returned by the OpenCL implementation that can be used to log additional information helpful in debugging the error.user_data is a pointer to user supplied data.
        /// </param>
        /// <param name="user_data"> 
        /// Passed as the user_data argument when pfn_notify is called. user_data can be NULL.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeContext CreateContextFromType(ref IntPtr properties, DeviceTypeFlags device_type, ContextNotifyDelegate pfn_notify, IntPtr user_data, [OutAttribute] out ErrorCode errcode_ret)
        {
            return CL.CreateContextFromType(ref properties, device_type, pfn_notify, user_data, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Create an OpenCL context from a device type that identifies the specific device(s) to use.
        /// </summary>
        /// <param name="properties"> 
        /// Specifies a list of context property names and their corresponding values. Each property name is immediately followed by the corresponding desired value. The list is terminated with 0. properties can be NULL in which case the platform that is selected is implementation-defined. The list of supported properties is described in the table below. cl_context_properties enumProperty valueDescriptionContextPlatformcl_platform_idSpecifies the platform to use.
        /// </param>
        /// <param name="device_type"> 
        /// A bit-field that identifies the type of device and is described in the table below. cl_device_typeDescriptionDeviceTypeCpuAn OpenCL device that is the host processor. The host processor runs the OpenCL implementations and is a single or multi-core CPU.DeviceTypeGpuAn OpenCL device that is a GPU. By this we mean that the device can also be used to accelerate a 3D API such as OpenGL or DirectX.DeviceTypeAcceleratorDedicated OpenCL accelerators (for example the IBM CELL Blade). These devices communicate with the host processor using a peripheral interconnect such as PCIe.DeviceTypeDefaultThe default OpenCL device in the system.DeviceTypeAllAll OpenCL devices available in the system.
        /// </param>
        /// <param name="pfn_notify"> 
        /// A callback function that can be registered by the application. This callback function will be used by the OpenCL implementation to report information on errors that occur in this context. This callback function may be called asynchronously by the OpenCL implementation. It is the application's responsibility to ensure that the callback function is thread-safe. If pfn_notify is NULL, no callback function is registered. The parameters to this callback function are: errinfo is a pointer to an error string.private_info and cb represent a pointer to binary data that is returned by the OpenCL implementation that can be used to log additional information helpful in debugging the error.user_data is a pointer to user supplied data.
        /// </param>
        /// <param name="user_data"> 
        /// Passed as the user_data argument when pfn_notify is called. user_data can be NULL.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeContext CreateContextFromType(IntPtr* properties, DeviceTypeFlags device_type, ContextNotifyDelegate pfn_notify, IntPtr user_data, [OutAttribute] ErrorCode* errcode_ret)
        {
            return CL.CreateContextFromType(properties, device_type, pfn_notify, user_data, errcode_ret);
        }

        #endregion
    }

    /// <summary>
    /// Defines methods to simplify ComputeContext usage.
    /// </summary>
    public static partial class ComputeContextExtensions
    {
        /// <summary>[requires: v1.0]
        /// Creates a buffer object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context used to create the buffer object.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information such as the memory arena that should be used to allocate the buffer object and how it will be used. The following table describes the possible values for flags: cl_mem_flagsDescriptionMemReadWrite This flag specifies that the memory object will be read and written by a kernel. This is the default. MemWriteOnlyThis flags specifies that the memory object will be written but not read by a kernel.Reading from a buffer or image object created with MemWriteOnly inside a kernel is undefined.MemReadOnlyThis flag specifies that the memory object is a read-only memory object when used inside a kernel.Writing to a buffer or image object created with MemReadOnly inside a kernel is undefined.MemUseHostPtrThis flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to use memory referenced by host_ptr as the storage bits for the memory object.OpenCL implementations are allowed to cache the buffer contents pointed to by host_ptr in device memory. This cached copy can be used when kernels are executed on a device.The result of OpenCL commands that operate on multiple buffer objects created with the same host_ptr or overlapping host regions is considered to be undefined.MemAllocHostPtrThis flag specifies that the application wants the OpenCL implementation to allocate memory from host accessible memory.MemAllocHostPtr and MemUseHostPtr are mutually exclusive.MemCopyHostPtr This flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to allocate memory for the memory object and copy the data from memory referenced by host_ptr. MemCopyHostPtr and MemUseHostPtr are mutually exclusive. MemCopyHostPtr can be used with MemAllocHostPtr to initialize the contents of the cl_mem object allocated using host-accessible (e.g. PCIe) memory.
        /// </param>
        /// <param name="size"> 
        /// The size in bytes of the buffer memory object to be allocated.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the buffer data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to the size bytes.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateBuffer(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, IntPtr size, IntPtr host_ptr, [OutAttribute] out ErrorCode errcode_ret)
        {
            return CL.CreateBuffer(context, flags, size, host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a buffer object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context used to create the buffer object.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information such as the memory arena that should be used to allocate the buffer object and how it will be used. The following table describes the possible values for flags: cl_mem_flagsDescriptionMemReadWrite This flag specifies that the memory object will be read and written by a kernel. This is the default. MemWriteOnlyThis flags specifies that the memory object will be written but not read by a kernel.Reading from a buffer or image object created with MemWriteOnly inside a kernel is undefined.MemReadOnlyThis flag specifies that the memory object is a read-only memory object when used inside a kernel.Writing to a buffer or image object created with MemReadOnly inside a kernel is undefined.MemUseHostPtrThis flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to use memory referenced by host_ptr as the storage bits for the memory object.OpenCL implementations are allowed to cache the buffer contents pointed to by host_ptr in device memory. This cached copy can be used when kernels are executed on a device.The result of OpenCL commands that operate on multiple buffer objects created with the same host_ptr or overlapping host regions is considered to be undefined.MemAllocHostPtrThis flag specifies that the application wants the OpenCL implementation to allocate memory from host accessible memory.MemAllocHostPtr and MemUseHostPtr are mutually exclusive.MemCopyHostPtr This flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to allocate memory for the memory object and copy the data from memory referenced by host_ptr. MemCopyHostPtr and MemUseHostPtr are mutually exclusive. MemCopyHostPtr can be used with MemAllocHostPtr to initialize the contents of the cl_mem object allocated using host-accessible (e.g. PCIe) memory.
        /// </param>
        /// <param name="size"> 
        /// The size in bytes of the buffer memory object to be allocated.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the buffer data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to the size bytes.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateBuffer(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, IntPtr size, IntPtr host_ptr, [OutAttribute] ErrorCode* errcode_ret)
        {
            return CL.CreateBuffer(context, flags, size, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a buffer object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context used to create the buffer object.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information such as the memory arena that should be used to allocate the buffer object and how it will be used. The following table describes the possible values for flags: cl_mem_flagsDescriptionMemReadWrite This flag specifies that the memory object will be read and written by a kernel. This is the default. MemWriteOnlyThis flags specifies that the memory object will be written but not read by a kernel.Reading from a buffer or image object created with MemWriteOnly inside a kernel is undefined.MemReadOnlyThis flag specifies that the memory object is a read-only memory object when used inside a kernel.Writing to a buffer or image object created with MemReadOnly inside a kernel is undefined.MemUseHostPtrThis flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to use memory referenced by host_ptr as the storage bits for the memory object.OpenCL implementations are allowed to cache the buffer contents pointed to by host_ptr in device memory. This cached copy can be used when kernels are executed on a device.The result of OpenCL commands that operate on multiple buffer objects created with the same host_ptr or overlapping host regions is considered to be undefined.MemAllocHostPtrThis flag specifies that the application wants the OpenCL implementation to allocate memory from host accessible memory.MemAllocHostPtr and MemUseHostPtr are mutually exclusive.MemCopyHostPtr This flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to allocate memory for the memory object and copy the data from memory referenced by host_ptr. MemCopyHostPtr and MemUseHostPtr are mutually exclusive. MemCopyHostPtr can be used with MemAllocHostPtr to initialize the contents of the cl_mem object allocated using host-accessible (e.g. PCIe) memory.
        /// </param>
        /// <param name="size"> 
        /// The size in bytes of the buffer memory object to be allocated.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the buffer data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to the size bytes.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateBuffer<T3>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, IntPtr size, [InAttribute, OutAttribute] T3[] host_ptr, [OutAttribute] out ErrorCode errcode_ret)
            where T3 : struct
        
        {
            return CL.CreateBuffer(context, flags, size, host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a buffer object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context used to create the buffer object.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information such as the memory arena that should be used to allocate the buffer object and how it will be used. The following table describes the possible values for flags: cl_mem_flagsDescriptionMemReadWrite This flag specifies that the memory object will be read and written by a kernel. This is the default. MemWriteOnlyThis flags specifies that the memory object will be written but not read by a kernel.Reading from a buffer or image object created with MemWriteOnly inside a kernel is undefined.MemReadOnlyThis flag specifies that the memory object is a read-only memory object when used inside a kernel.Writing to a buffer or image object created with MemReadOnly inside a kernel is undefined.MemUseHostPtrThis flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to use memory referenced by host_ptr as the storage bits for the memory object.OpenCL implementations are allowed to cache the buffer contents pointed to by host_ptr in device memory. This cached copy can be used when kernels are executed on a device.The result of OpenCL commands that operate on multiple buffer objects created with the same host_ptr or overlapping host regions is considered to be undefined.MemAllocHostPtrThis flag specifies that the application wants the OpenCL implementation to allocate memory from host accessible memory.MemAllocHostPtr and MemUseHostPtr are mutually exclusive.MemCopyHostPtr This flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to allocate memory for the memory object and copy the data from memory referenced by host_ptr. MemCopyHostPtr and MemUseHostPtr are mutually exclusive. MemCopyHostPtr can be used with MemAllocHostPtr to initialize the contents of the cl_mem object allocated using host-accessible (e.g. PCIe) memory.
        /// </param>
        /// <param name="size"> 
        /// The size in bytes of the buffer memory object to be allocated.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the buffer data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to the size bytes.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateBuffer<T3>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, IntPtr size, [InAttribute, OutAttribute] T3[] host_ptr, [OutAttribute] ErrorCode* errcode_ret)
            where T3 : struct
        
        {
            return CL.CreateBuffer(context, flags, size, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a buffer object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context used to create the buffer object.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information such as the memory arena that should be used to allocate the buffer object and how it will be used. The following table describes the possible values for flags: cl_mem_flagsDescriptionMemReadWrite This flag specifies that the memory object will be read and written by a kernel. This is the default. MemWriteOnlyThis flags specifies that the memory object will be written but not read by a kernel.Reading from a buffer or image object created with MemWriteOnly inside a kernel is undefined.MemReadOnlyThis flag specifies that the memory object is a read-only memory object when used inside a kernel.Writing to a buffer or image object created with MemReadOnly inside a kernel is undefined.MemUseHostPtrThis flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to use memory referenced by host_ptr as the storage bits for the memory object.OpenCL implementations are allowed to cache the buffer contents pointed to by host_ptr in device memory. This cached copy can be used when kernels are executed on a device.The result of OpenCL commands that operate on multiple buffer objects created with the same host_ptr or overlapping host regions is considered to be undefined.MemAllocHostPtrThis flag specifies that the application wants the OpenCL implementation to allocate memory from host accessible memory.MemAllocHostPtr and MemUseHostPtr are mutually exclusive.MemCopyHostPtr This flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to allocate memory for the memory object and copy the data from memory referenced by host_ptr. MemCopyHostPtr and MemUseHostPtr are mutually exclusive. MemCopyHostPtr can be used with MemAllocHostPtr to initialize the contents of the cl_mem object allocated using host-accessible (e.g. PCIe) memory.
        /// </param>
        /// <param name="size"> 
        /// The size in bytes of the buffer memory object to be allocated.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the buffer data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to the size bytes.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateBuffer<T3>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, IntPtr size, [InAttribute, OutAttribute] T3[,] host_ptr, [OutAttribute] out ErrorCode errcode_ret)
            where T3 : struct
        
        {
            return CL.CreateBuffer(context, flags, size, host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a buffer object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context used to create the buffer object.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information such as the memory arena that should be used to allocate the buffer object and how it will be used. The following table describes the possible values for flags: cl_mem_flagsDescriptionMemReadWrite This flag specifies that the memory object will be read and written by a kernel. This is the default. MemWriteOnlyThis flags specifies that the memory object will be written but not read by a kernel.Reading from a buffer or image object created with MemWriteOnly inside a kernel is undefined.MemReadOnlyThis flag specifies that the memory object is a read-only memory object when used inside a kernel.Writing to a buffer or image object created with MemReadOnly inside a kernel is undefined.MemUseHostPtrThis flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to use memory referenced by host_ptr as the storage bits for the memory object.OpenCL implementations are allowed to cache the buffer contents pointed to by host_ptr in device memory. This cached copy can be used when kernels are executed on a device.The result of OpenCL commands that operate on multiple buffer objects created with the same host_ptr or overlapping host regions is considered to be undefined.MemAllocHostPtrThis flag specifies that the application wants the OpenCL implementation to allocate memory from host accessible memory.MemAllocHostPtr and MemUseHostPtr are mutually exclusive.MemCopyHostPtr This flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to allocate memory for the memory object and copy the data from memory referenced by host_ptr. MemCopyHostPtr and MemUseHostPtr are mutually exclusive. MemCopyHostPtr can be used with MemAllocHostPtr to initialize the contents of the cl_mem object allocated using host-accessible (e.g. PCIe) memory.
        /// </param>
        /// <param name="size"> 
        /// The size in bytes of the buffer memory object to be allocated.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the buffer data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to the size bytes.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateBuffer<T3>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, IntPtr size, [InAttribute, OutAttribute] T3[,] host_ptr, [OutAttribute] ErrorCode* errcode_ret)
            where T3 : struct
        
        {
            return CL.CreateBuffer(context, flags, size, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a buffer object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context used to create the buffer object.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information such as the memory arena that should be used to allocate the buffer object and how it will be used. The following table describes the possible values for flags: cl_mem_flagsDescriptionMemReadWrite This flag specifies that the memory object will be read and written by a kernel. This is the default. MemWriteOnlyThis flags specifies that the memory object will be written but not read by a kernel.Reading from a buffer or image object created with MemWriteOnly inside a kernel is undefined.MemReadOnlyThis flag specifies that the memory object is a read-only memory object when used inside a kernel.Writing to a buffer or image object created with MemReadOnly inside a kernel is undefined.MemUseHostPtrThis flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to use memory referenced by host_ptr as the storage bits for the memory object.OpenCL implementations are allowed to cache the buffer contents pointed to by host_ptr in device memory. This cached copy can be used when kernels are executed on a device.The result of OpenCL commands that operate on multiple buffer objects created with the same host_ptr or overlapping host regions is considered to be undefined.MemAllocHostPtrThis flag specifies that the application wants the OpenCL implementation to allocate memory from host accessible memory.MemAllocHostPtr and MemUseHostPtr are mutually exclusive.MemCopyHostPtr This flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to allocate memory for the memory object and copy the data from memory referenced by host_ptr. MemCopyHostPtr and MemUseHostPtr are mutually exclusive. MemCopyHostPtr can be used with MemAllocHostPtr to initialize the contents of the cl_mem object allocated using host-accessible (e.g. PCIe) memory.
        /// </param>
        /// <param name="size"> 
        /// The size in bytes of the buffer memory object to be allocated.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the buffer data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to the size bytes.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateBuffer<T3>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, IntPtr size, [InAttribute, OutAttribute] T3[,,] host_ptr, [OutAttribute] out ErrorCode errcode_ret)
            where T3 : struct
        
        {
            return CL.CreateBuffer(context, flags, size, host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a buffer object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context used to create the buffer object.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information such as the memory arena that should be used to allocate the buffer object and how it will be used. The following table describes the possible values for flags: cl_mem_flagsDescriptionMemReadWrite This flag specifies that the memory object will be read and written by a kernel. This is the default. MemWriteOnlyThis flags specifies that the memory object will be written but not read by a kernel.Reading from a buffer or image object created with MemWriteOnly inside a kernel is undefined.MemReadOnlyThis flag specifies that the memory object is a read-only memory object when used inside a kernel.Writing to a buffer or image object created with MemReadOnly inside a kernel is undefined.MemUseHostPtrThis flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to use memory referenced by host_ptr as the storage bits for the memory object.OpenCL implementations are allowed to cache the buffer contents pointed to by host_ptr in device memory. This cached copy can be used when kernels are executed on a device.The result of OpenCL commands that operate on multiple buffer objects created with the same host_ptr or overlapping host regions is considered to be undefined.MemAllocHostPtrThis flag specifies that the application wants the OpenCL implementation to allocate memory from host accessible memory.MemAllocHostPtr and MemUseHostPtr are mutually exclusive.MemCopyHostPtr This flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to allocate memory for the memory object and copy the data from memory referenced by host_ptr. MemCopyHostPtr and MemUseHostPtr are mutually exclusive. MemCopyHostPtr can be used with MemAllocHostPtr to initialize the contents of the cl_mem object allocated using host-accessible (e.g. PCIe) memory.
        /// </param>
        /// <param name="size"> 
        /// The size in bytes of the buffer memory object to be allocated.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the buffer data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to the size bytes.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateBuffer<T3>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, IntPtr size, [InAttribute, OutAttribute] T3[,,] host_ptr, [OutAttribute] ErrorCode* errcode_ret)
            where T3 : struct
        
        {
            return CL.CreateBuffer(context, flags, size, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a buffer object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context used to create the buffer object.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information such as the memory arena that should be used to allocate the buffer object and how it will be used. The following table describes the possible values for flags: cl_mem_flagsDescriptionMemReadWrite This flag specifies that the memory object will be read and written by a kernel. This is the default. MemWriteOnlyThis flags specifies that the memory object will be written but not read by a kernel.Reading from a buffer or image object created with MemWriteOnly inside a kernel is undefined.MemReadOnlyThis flag specifies that the memory object is a read-only memory object when used inside a kernel.Writing to a buffer or image object created with MemReadOnly inside a kernel is undefined.MemUseHostPtrThis flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to use memory referenced by host_ptr as the storage bits for the memory object.OpenCL implementations are allowed to cache the buffer contents pointed to by host_ptr in device memory. This cached copy can be used when kernels are executed on a device.The result of OpenCL commands that operate on multiple buffer objects created with the same host_ptr or overlapping host regions is considered to be undefined.MemAllocHostPtrThis flag specifies that the application wants the OpenCL implementation to allocate memory from host accessible memory.MemAllocHostPtr and MemUseHostPtr are mutually exclusive.MemCopyHostPtr This flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to allocate memory for the memory object and copy the data from memory referenced by host_ptr. MemCopyHostPtr and MemUseHostPtr are mutually exclusive. MemCopyHostPtr can be used with MemAllocHostPtr to initialize the contents of the cl_mem object allocated using host-accessible (e.g. PCIe) memory.
        /// </param>
        /// <param name="size"> 
        /// The size in bytes of the buffer memory object to be allocated.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the buffer data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to the size bytes.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateBuffer<T3>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, IntPtr size, [InAttribute, OutAttribute] ref T3 host_ptr, [OutAttribute] out ErrorCode errcode_ret)
            where T3 : struct
        
        {
            return CL.CreateBuffer(context, flags, size, ref host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a buffer object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context used to create the buffer object.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information such as the memory arena that should be used to allocate the buffer object and how it will be used. The following table describes the possible values for flags: cl_mem_flagsDescriptionMemReadWrite This flag specifies that the memory object will be read and written by a kernel. This is the default. MemWriteOnlyThis flags specifies that the memory object will be written but not read by a kernel.Reading from a buffer or image object created with MemWriteOnly inside a kernel is undefined.MemReadOnlyThis flag specifies that the memory object is a read-only memory object when used inside a kernel.Writing to a buffer or image object created with MemReadOnly inside a kernel is undefined.MemUseHostPtrThis flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to use memory referenced by host_ptr as the storage bits for the memory object.OpenCL implementations are allowed to cache the buffer contents pointed to by host_ptr in device memory. This cached copy can be used when kernels are executed on a device.The result of OpenCL commands that operate on multiple buffer objects created with the same host_ptr or overlapping host regions is considered to be undefined.MemAllocHostPtrThis flag specifies that the application wants the OpenCL implementation to allocate memory from host accessible memory.MemAllocHostPtr and MemUseHostPtr are mutually exclusive.MemCopyHostPtr This flag is valid only if host_ptr is not NULL. If specified, it indicates that the application wants the OpenCL implementation to allocate memory for the memory object and copy the data from memory referenced by host_ptr. MemCopyHostPtr and MemUseHostPtr are mutually exclusive. MemCopyHostPtr can be used with MemAllocHostPtr to initialize the contents of the cl_mem object allocated using host-accessible (e.g. PCIe) memory.
        /// </param>
        /// <param name="size"> 
        /// The size in bytes of the buffer memory object to be allocated.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the buffer data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to the size bytes.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateBuffer<T3>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, IntPtr size, [InAttribute, OutAttribute] ref T3 host_ptr, [OutAttribute] ErrorCode* errcode_ret)
            where T3 : struct
        
        {
            return CL.CreateBuffer(context, flags, size, ref host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Create a command-queue on a specific device.
        /// </summary>
        /// <param name="context"> 
        /// Must be a valid OpenCL context.
        /// </param>
        /// <param name="device"> 
        /// Must be a device associated with context. It can either be in the list of devices specified when context is created using clCreateContext or have the same device type as the device type specified when the context is created using clCreateContextFromType.
        /// </param>
        /// <param name="properties"> 
        /// Specifies a list of properties for the command-queue. This is a bit-field. Only command-queue properties specified in the table below can be set in properties; otherwise the value specified in properties is considered to be not valid. Command-Queue PropertiesDescriptionQueueOutOfOrderExecModeEnableDetermines whether the commands queued in the command-queue are executed in-order or out-of-order. If set, the commands in the command-queue are executed out-of-order. Otherwise, commands are executed in-order.QueueProfilingEnableEnable or disable profiling of commands in the command-queue. If set, the profiling of commands is enabled. Otherwise profiling of commands is disabled. See  clGetEventProfilingInfo for more information.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is Null, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static CommandQueue CreateCommandQueue(this ComputeContext context, ComputeDevice device, CommandQueueFlags properties, [OutAttribute] out ErrorCode errcode_ret)
        {
            return CL.CreateCommandQueue(context, device, properties, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Create a command-queue on a specific device.
        /// </summary>
        /// <param name="context"> 
        /// Must be a valid OpenCL context.
        /// </param>
        /// <param name="device"> 
        /// Must be a device associated with context. It can either be in the list of devices specified when context is created using clCreateContext or have the same device type as the device type specified when the context is created using clCreateContextFromType.
        /// </param>
        /// <param name="properties"> 
        /// Specifies a list of properties for the command-queue. This is a bit-field. Only command-queue properties specified in the table below can be set in properties; otherwise the value specified in properties is considered to be not valid. Command-Queue PropertiesDescriptionQueueOutOfOrderExecModeEnableDetermines whether the commands queued in the command-queue are executed in-order or out-of-order. If set, the commands in the command-queue are executed out-of-order. Otherwise, commands are executed in-order.QueueProfilingEnableEnable or disable profiling of commands in the command-queue. If set, the profiling of commands is enabled. Otherwise profiling of commands is disabled. See  clGetEventProfilingInfo for more information.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is Null, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe CommandQueue CreateCommandQueue(this ComputeContext context, ComputeDevice device, CommandQueueFlags properties, [OutAttribute] ErrorCode* errcode_ret)
        {
            return CL.CreateCommandQueue(context, device, properties, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage2D(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat[] image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, [OutAttribute] Int32[] errcode_ret)
        {
            return CL.CreateImage2D(context, flags, image_format, image_width, image_height, image_row_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage2D<T6>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat[] image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, [InAttribute, OutAttribute] T6[] host_ptr, [OutAttribute] Int32[] errcode_ret)
            where T6 : struct
        
        {
            return CL.CreateImage2D(context, flags, image_format, image_width, image_height, image_row_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage2D<T6>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat[] image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, [InAttribute, OutAttribute] T6[,] host_ptr, [OutAttribute] Int32[] errcode_ret)
            where T6 : struct
        
        {
            return CL.CreateImage2D(context, flags, image_format, image_width, image_height, image_row_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage2D<T6>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat[] image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, [InAttribute, OutAttribute] T6[,,] host_ptr, [OutAttribute] Int32[] errcode_ret)
            where T6 : struct
        
        {
            return CL.CreateImage2D(context, flags, image_format, image_width, image_height, image_row_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage2D<T6>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat[] image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, [InAttribute, OutAttribute] ref T6 host_ptr, [OutAttribute] Int32[] errcode_ret)
            where T6 : struct
        
        {
            return CL.CreateImage2D(context, flags, image_format, image_width, image_height, image_row_pitch, ref host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage2D(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, [OutAttribute] out Int32 errcode_ret)
        {
            return CL.CreateImage2D(context, flags, ref image_format, image_width, image_height, image_row_pitch, host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage2D<T6>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, [InAttribute, OutAttribute] T6[] host_ptr, [OutAttribute] out Int32 errcode_ret)
            where T6 : struct
        
        {
            return CL.CreateImage2D(context, flags, ref image_format, image_width, image_height, image_row_pitch, host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage2D<T6>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, [InAttribute, OutAttribute] T6[,] host_ptr, [OutAttribute] out Int32 errcode_ret)
            where T6 : struct
        
        {
            return CL.CreateImage2D(context, flags, ref image_format, image_width, image_height, image_row_pitch, host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage2D<T6>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, [InAttribute, OutAttribute] T6[,,] host_ptr, [OutAttribute] out Int32 errcode_ret)
            where T6 : struct
        
        {
            return CL.CreateImage2D(context, flags, ref image_format, image_width, image_height, image_row_pitch, host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage2D<T6>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, [InAttribute, OutAttribute] ref T6 host_ptr, [OutAttribute] out Int32 errcode_ret)
            where T6 : struct
        
        {
            return CL.CreateImage2D(context, flags, ref image_format, image_width, image_height, image_row_pitch, ref host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateImage2D(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat* image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, [OutAttribute] Int32* errcode_ret)
        {
            return CL.CreateImage2D(context, flags, image_format, image_width, image_height, image_row_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateImage2D<T6>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat* image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, [InAttribute, OutAttribute] T6[] host_ptr, [OutAttribute] Int32* errcode_ret)
            where T6 : struct
        
        {
            return CL.CreateImage2D(context, flags, image_format, image_width, image_height, image_row_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateImage2D<T6>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat* image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, [InAttribute, OutAttribute] T6[,] host_ptr, [OutAttribute] Int32* errcode_ret)
            where T6 : struct
        
        {
            return CL.CreateImage2D(context, flags, image_format, image_width, image_height, image_row_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateImage2D<T6>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat* image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, [InAttribute, OutAttribute] T6[,,] host_ptr, [OutAttribute] Int32* errcode_ret)
            where T6 : struct
        
        {
            return CL.CreateImage2D(context, flags, image_format, image_width, image_height, image_row_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 2D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_row_pitch * image_height. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent scanlines. Each scanline is stored as a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateImage2D<T6>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat* image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, [InAttribute, OutAttribute] ref T6 host_ptr, [OutAttribute] Int32* errcode_ret)
            where T6 : struct
        
        {
            return CL.CreateImage2D(context, flags, image_format, image_width, image_height, image_row_pitch, ref host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage3D(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat[] image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, [OutAttribute] Int32[] errcode_ret)
        {
            return CL.CreateImage3D(context, flags, image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage3D<T8>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat[] image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, [InAttribute, OutAttribute] T8[] host_ptr, [OutAttribute] Int32[] errcode_ret)
            where T8 : struct
        
        {
            return CL.CreateImage3D(context, flags, image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage3D<T8>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat[] image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, [InAttribute, OutAttribute] T8[,] host_ptr, [OutAttribute] Int32[] errcode_ret)
            where T8 : struct
        
        {
            return CL.CreateImage3D(context, flags, image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage3D<T8>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat[] image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, [InAttribute, OutAttribute] T8[,,] host_ptr, [OutAttribute] Int32[] errcode_ret)
            where T8 : struct
        
        {
            return CL.CreateImage3D(context, flags, image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage3D<T8>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat[] image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, [InAttribute, OutAttribute] ref T8 host_ptr, [OutAttribute] Int32[] errcode_ret)
            where T8 : struct
        
        {
            return CL.CreateImage3D(context, flags, image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, ref host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage3D(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, [OutAttribute] out Int32 errcode_ret)
        {
            return CL.CreateImage3D(context, flags, ref image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage3D<T8>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, [InAttribute, OutAttribute] T8[] host_ptr, [OutAttribute] out Int32 errcode_ret)
            where T8 : struct
        
        {
            return CL.CreateImage3D(context, flags, ref image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage3D<T8>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, [InAttribute, OutAttribute] T8[,] host_ptr, [OutAttribute] out Int32 errcode_ret)
            where T8 : struct
        
        {
            return CL.CreateImage3D(context, flags, ref image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage3D<T8>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, [InAttribute, OutAttribute] T8[,,] host_ptr, [OutAttribute] out Int32 errcode_ret)
            where T8 : struct
        
        {
            return CL.CreateImage3D(context, flags, ref image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeMemory CreateImage3D<T8>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, [InAttribute, OutAttribute] ref T8 host_ptr, [OutAttribute] out Int32 errcode_ret)
            where T8 : struct
        
        {
            return CL.CreateImage3D(context, flags, ref image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, ref host_ptr, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateImage3D(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat* image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, [OutAttribute] Int32* errcode_ret)
        {
            return CL.CreateImage3D(context, flags, image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateImage3D<T8>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat* image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, [InAttribute, OutAttribute] T8[] host_ptr, [OutAttribute] Int32* errcode_ret)
            where T8 : struct
        
        {
            return CL.CreateImage3D(context, flags, image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateImage3D<T8>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat* image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, [InAttribute, OutAttribute] T8[,] host_ptr, [OutAttribute] Int32* errcode_ret)
            where T8 : struct
        
        {
            return CL.CreateImage3D(context, flags, image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateImage3D<T8>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat* image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, [InAttribute, OutAttribute] T8[,,] host_ptr, [OutAttribute] Int32* errcode_ret)
            where T8 : struct
        
        {
            return CL.CreateImage3D(context, flags, image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a 3D image object.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object is to be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the table List of supported cl_mem_flags values for clCreateBuffer.
        /// </param>
        /// <param name="image_format"> 
        /// A pointer to a structure that describes format properties of the image to be allocated. See cl_image_format for a detailed description of the image format descriptor.
        /// </param>
        /// <param name="image_width"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_height"> 
        /// The width and height of the image in pixels. These must be values greater than or equal to 1.
        /// </param>
        /// <param name="image_depth"> 
        /// The depth of the image in pixels. This must be a value greater than 1.
        /// </param>
        /// <param name="image_row_pitch"> 
        /// The scan-line pitch in bytes. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_width * size of element in bytes if host_ptr is not NULL. If host_ptr is not NULL and image_row_pitch is equal to 0, image_row_pitch is calculated as image_width * size of element in bytes. If image_row_pitch is not 0, it must be a multiple of the image element size in bytes.
        /// </param>
        /// <param name="image_slice_pitch"> 
        /// The size in bytes of each 2D slice in the 3D image. This must be 0 if host_ptr is NULL and can be either 0 or greater than or equal to image_row_pitch * image_height if host_ptr is not NULL. If host_ptr is not NULL and image_slice_pitch equal to 0, image_slice_pitch is calculated as image_row_pitch * image_height. If image_slice_pitch is not 0, it must be a multiple of the image_row_pitch.
        /// </param>
        /// <param name="host_ptr"> 
        /// A pointer to the image data that may already be allocated by the application. The size of the buffer that host_ptr points to must be greater than or equal to image_slice_pitch * image_depth. The size of each element in bytes must be a power of 2. The image data specified by host_ptr is stored as a linear sequence of adjacent 2D slices. Each 2D slice is a linear sequence of adjacent scanlines. Each scanline is a linear sequence of image elements.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Will return an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeMemory CreateImage3D<T8>(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, ImageFormat* image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, [InAttribute, OutAttribute] ref T8 host_ptr, [OutAttribute] Int32* errcode_ret)
            where T8 : struct
        
        {
            return CL.CreateImage3D(context, flags, image_format, image_width, image_height, image_depth, image_row_pitch, image_slice_pitch, ref host_ptr, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a program object for a context, and loads the source code specified by the text strings in the strings array into the program object.
        /// </summary>
        /// <param name="context"> 
        /// Must be a valid OpenCL context.
        /// </param>
        /// <param name="count"> 
        /// An array of count pointers to optionally null-terminated character strings that make up the source code.
        /// </param>
        /// <param name="strings"> 
        /// An array of count pointers to optionally null-terminated character strings that make up the source code.
        /// </param>
        /// <param name="lengths"> 
        /// An array with the number of chars in each string (the string length). If an element in lengths is zero, its accompanying string is null-terminated. If lengths is NULL, all strings in the strings argument are considered null-terminated. Any length value passed in that is greater than zero excludes the null terminator in its count.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeProgram CreateProgramWithSource(this ComputeContext context, Int32 count, IntPtr strings, IntPtr* lengths, [OutAttribute] ErrorCode* errcode_ret)
        {
            return CL.CreateProgramWithSource(context, count, strings, lengths, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a program object for a context, and loads the source code specified by the text strings in the strings array into the program object.
        /// </summary>
        /// <param name="context"> 
        /// Must be a valid OpenCL context.
        /// </param>
        /// <param name="count"> 
        /// An array of count pointers to optionally null-terminated character strings that make up the source code.
        /// </param>
        /// <param name="strings"> 
        /// An array of count pointers to optionally null-terminated character strings that make up the source code.
        /// </param>
        /// <param name="lengths"> 
        /// An array with the number of chars in each string (the string length). If an element in lengths is zero, its accompanying string is null-terminated. If lengths is NULL, all strings in the strings argument are considered null-terminated. Any length value passed in that is greater than zero excludes the null terminator in its count.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeProgram CreateProgramWithSource(this ComputeContext context, Int32 count, String[] strings, IntPtr[] lengths, [OutAttribute] out ErrorCode errcode_ret)
        {
            return CL.CreateProgramWithSource(context, count, strings, lengths, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a program object for a context, and loads the source code specified by the text strings in the strings array into the program object.
        /// </summary>
        /// <param name="context"> 
        /// Must be a valid OpenCL context.
        /// </param>
        /// <param name="count"> 
        /// An array of count pointers to optionally null-terminated character strings that make up the source code.
        /// </param>
        /// <param name="strings"> 
        /// An array of count pointers to optionally null-terminated character strings that make up the source code.
        /// </param>
        /// <param name="lengths"> 
        /// An array with the number of chars in each string (the string length). If an element in lengths is zero, its accompanying string is null-terminated. If lengths is NULL, all strings in the strings argument are considered null-terminated. Any length value passed in that is greater than zero excludes the null terminator in its count.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeProgram CreateProgramWithSource(this ComputeContext context, Int32 count, ref String strings, ref IntPtr lengths, [OutAttribute] out ErrorCode errcode_ret)
        {
            return CL.CreateProgramWithSource(context, count, ref strings, ref lengths, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a sampler object.
        /// </summary>
        /// <param name="context"> 
        /// Must be a valid OpenCL context.
        /// </param>
        /// <param name="normalized_coords"> 
        /// Determines if the image coordinates specified are normalized (if normalized_coords is True) or not (if normalized_coords is False).
        /// </param>
        /// <param name="addressing_mode"> 
        /// Specifies how out-of-range image coordinates are handled when reading from an image. This can be set to AddressRepeat, AddressClampToEdge, AddressClamp, and AddressNone.
        /// </param>
        /// <param name="filter_mode"> 
        /// Specifies the type of filter that must be applied when reading an image. This can be FilterNearest or FilterLinear.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeSampler CreateSampler(this ComputeContext context, bool normalized_coords, OpenTK.Compute.CL10.AddressingMode addressing_mode, OpenTK.Compute.CL10.FilterMode filter_mode, [OutAttribute] out ErrorCode errcode_ret)
        {
            return CL.CreateSampler(context, normalized_coords, addressing_mode, filter_mode, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a sampler object.
        /// </summary>
        /// <param name="context"> 
        /// Must be a valid OpenCL context.
        /// </param>
        /// <param name="normalized_coords"> 
        /// Determines if the image coordinates specified are normalized (if normalized_coords is True) or not (if normalized_coords is False).
        /// </param>
        /// <param name="addressing_mode"> 
        /// Specifies how out-of-range image coordinates are handled when reading from an image. This can be set to AddressRepeat, AddressClampToEdge, AddressClamp, and AddressNone.
        /// </param>
        /// <param name="filter_mode"> 
        /// Specifies the type of filter that must be applied when reading an image. This can be FilterNearest or FilterLinear.
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeSampler CreateSampler(this ComputeContext context, bool normalized_coords, OpenTK.Compute.CL10.AddressingMode addressing_mode, OpenTK.Compute.CL10.FilterMode filter_mode, [OutAttribute] ErrorCode* errcode_ret)
        {
            return CL.CreateSampler(context, normalized_coords, addressing_mode, filter_mode, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a context.
        /// </summary>
        /// <param name="context"> 
        /// Specifies the OpenCL context being queried.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that specifies the information to query. The valid values for param_name are: cl_context_infoReturn TypeInformation returned in param_valueContextReferenceCountcl_uint Return the context reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. ContextDevicescl_device_id[] Return the list of devices in context. ContextPropertiescl_context_properties[] Return the properties argument specified in clCreateContext.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetContextInfo(this ComputeContext context, OpenTK.Compute.CL10.ContextInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] out IntPtr param_value_size_ret)
        {
            return CL.GetContextInfo(context, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a context.
        /// </summary>
        /// <param name="context"> 
        /// Specifies the OpenCL context being queried.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that specifies the information to query. The valid values for param_name are: cl_context_infoReturn TypeInformation returned in param_valueContextReferenceCountcl_uint Return the context reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. ContextDevicescl_device_id[] Return the list of devices in context. ContextPropertiescl_context_properties[] Return the properties argument specified in clCreateContext.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetContextInfo(this ComputeContext context, OpenTK.Compute.CL10.ContextInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] IntPtr* param_value_size_ret)
        {
            return CL.GetContextInfo(context, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a context.
        /// </summary>
        /// <param name="context"> 
        /// Specifies the OpenCL context being queried.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that specifies the information to query. The valid values for param_name are: cl_context_infoReturn TypeInformation returned in param_valueContextReferenceCountcl_uint Return the context reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. ContextDevicescl_device_id[] Return the list of devices in context. ContextPropertiescl_context_properties[] Return the properties argument specified in clCreateContext.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetContextInfo<T3>(this ComputeContext context, OpenTK.Compute.CL10.ContextInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetContextInfo(context, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a context.
        /// </summary>
        /// <param name="context"> 
        /// Specifies the OpenCL context being queried.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that specifies the information to query. The valid values for param_name are: cl_context_infoReturn TypeInformation returned in param_valueContextReferenceCountcl_uint Return the context reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. ContextDevicescl_device_id[] Return the list of devices in context. ContextPropertiescl_context_properties[] Return the properties argument specified in clCreateContext.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetContextInfo<T3>(this ComputeContext context, OpenTK.Compute.CL10.ContextInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetContextInfo(context, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a context.
        /// </summary>
        /// <param name="context"> 
        /// Specifies the OpenCL context being queried.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that specifies the information to query. The valid values for param_name are: cl_context_infoReturn TypeInformation returned in param_valueContextReferenceCountcl_uint Return the context reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. ContextDevicescl_device_id[] Return the list of devices in context. ContextPropertiescl_context_properties[] Return the properties argument specified in clCreateContext.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetContextInfo<T3>(this ComputeContext context, OpenTK.Compute.CL10.ContextInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetContextInfo(context, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a context.
        /// </summary>
        /// <param name="context"> 
        /// Specifies the OpenCL context being queried.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that specifies the information to query. The valid values for param_name are: cl_context_infoReturn TypeInformation returned in param_valueContextReferenceCountcl_uint Return the context reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. ContextDevicescl_device_id[] Return the list of devices in context. ContextPropertiescl_context_properties[] Return the properties argument specified in clCreateContext.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetContextInfo<T3>(this ComputeContext context, OpenTK.Compute.CL10.ContextInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetContextInfo(context, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a context.
        /// </summary>
        /// <param name="context"> 
        /// Specifies the OpenCL context being queried.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that specifies the information to query. The valid values for param_name are: cl_context_infoReturn TypeInformation returned in param_valueContextReferenceCountcl_uint Return the context reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. ContextDevicescl_device_id[] Return the list of devices in context. ContextPropertiescl_context_properties[] Return the properties argument specified in clCreateContext.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetContextInfo<T3>(this ComputeContext context, OpenTK.Compute.CL10.ContextInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetContextInfo(context, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a context.
        /// </summary>
        /// <param name="context"> 
        /// Specifies the OpenCL context being queried.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that specifies the information to query. The valid values for param_name are: cl_context_infoReturn TypeInformation returned in param_valueContextReferenceCountcl_uint Return the context reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. ContextDevicescl_device_id[] Return the list of devices in context. ContextPropertiescl_context_properties[] Return the properties argument specified in clCreateContext.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetContextInfo<T3>(this ComputeContext context, OpenTK.Compute.CL10.ContextInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetContextInfo(context, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a context.
        /// </summary>
        /// <param name="context"> 
        /// Specifies the OpenCL context being queried.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that specifies the information to query. The valid values for param_name are: cl_context_infoReturn TypeInformation returned in param_valueContextReferenceCountcl_uint Return the context reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. ContextDevicescl_device_id[] Return the list of devices in context. ContextPropertiescl_context_properties[] Return the properties argument specified in clCreateContext.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetContextInfo<T3>(this ComputeContext context, OpenTK.Compute.CL10.ContextInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetContextInfo(context, param_name, param_value_size, ref param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Query information about a context.
        /// </summary>
        /// <param name="context"> 
        /// Specifies the OpenCL context being queried.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that specifies the information to query. The valid values for param_name are: cl_context_infoReturn TypeInformation returned in param_valueContextReferenceCountcl_uint Return the context reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. ContextDevicescl_device_id[] Return the list of devices in context. ContextPropertiescl_context_properties[] Return the properties argument specified in clCreateContext.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetContextInfo<T3>(this ComputeContext context, OpenTK.Compute.CL10.ContextInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetContextInfo(context, param_name, param_value_size, ref param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Get information about an OpenCL device.
        /// </summary>
        /// <param name="device"> 
        /// Refers to the device returned by clGetDeviceIDs.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that identifies the device information being queried. It can be one of the values as specified in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size in bytes must be greater than or equal to size of return type specified in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory location where appropriate values for a given param_name as specified in the table below will be returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetDeviceInfo(this ComputeDevice device, OpenTK.Compute.CL10.DeviceInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] out IntPtr param_value_size_ret)
        {
            return CL.GetDeviceInfo(device, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Get information about an OpenCL device.
        /// </summary>
        /// <param name="device"> 
        /// Refers to the device returned by clGetDeviceIDs.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that identifies the device information being queried. It can be one of the values as specified in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size in bytes must be greater than or equal to size of return type specified in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory location where appropriate values for a given param_name as specified in the table below will be returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetDeviceInfo(this ComputeDevice device, OpenTK.Compute.CL10.DeviceInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] IntPtr* param_value_size_ret)
        {
            return CL.GetDeviceInfo(device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Get information about an OpenCL device.
        /// </summary>
        /// <param name="device"> 
        /// Refers to the device returned by clGetDeviceIDs.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that identifies the device information being queried. It can be one of the values as specified in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size in bytes must be greater than or equal to size of return type specified in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory location where appropriate values for a given param_name as specified in the table below will be returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetDeviceInfo<T3>(this ComputeDevice device, OpenTK.Compute.CL10.DeviceInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetDeviceInfo(device, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Get information about an OpenCL device.
        /// </summary>
        /// <param name="device"> 
        /// Refers to the device returned by clGetDeviceIDs.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that identifies the device information being queried. It can be one of the values as specified in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size in bytes must be greater than or equal to size of return type specified in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory location where appropriate values for a given param_name as specified in the table below will be returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetDeviceInfo<T3>(this ComputeDevice device, OpenTK.Compute.CL10.DeviceInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetDeviceInfo(device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Get information about an OpenCL device.
        /// </summary>
        /// <param name="device"> 
        /// Refers to the device returned by clGetDeviceIDs.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that identifies the device information being queried. It can be one of the values as specified in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size in bytes must be greater than or equal to size of return type specified in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory location where appropriate values for a given param_name as specified in the table below will be returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetDeviceInfo<T3>(this ComputeDevice device, OpenTK.Compute.CL10.DeviceInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetDeviceInfo(device, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Get information about an OpenCL device.
        /// </summary>
        /// <param name="device"> 
        /// Refers to the device returned by clGetDeviceIDs.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that identifies the device information being queried. It can be one of the values as specified in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size in bytes must be greater than or equal to size of return type specified in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory location where appropriate values for a given param_name as specified in the table below will be returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetDeviceInfo<T3>(this ComputeDevice device, OpenTK.Compute.CL10.DeviceInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetDeviceInfo(device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Get information about an OpenCL device.
        /// </summary>
        /// <param name="device"> 
        /// Refers to the device returned by clGetDeviceIDs.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that identifies the device information being queried. It can be one of the values as specified in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size in bytes must be greater than or equal to size of return type specified in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory location where appropriate values for a given param_name as specified in the table below will be returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetDeviceInfo<T3>(this ComputeDevice device, OpenTK.Compute.CL10.DeviceInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetDeviceInfo(device, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Get information about an OpenCL device.
        /// </summary>
        /// <param name="device"> 
        /// Refers to the device returned by clGetDeviceIDs.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that identifies the device information being queried. It can be one of the values as specified in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size in bytes must be greater than or equal to size of return type specified in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory location where appropriate values for a given param_name as specified in the table below will be returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetDeviceInfo<T3>(this ComputeDevice device, OpenTK.Compute.CL10.DeviceInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetDeviceInfo(device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Get information about an OpenCL device.
        /// </summary>
        /// <param name="device"> 
        /// Refers to the device returned by clGetDeviceIDs.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that identifies the device information being queried. It can be one of the values as specified in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size in bytes must be greater than or equal to size of return type specified in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory location where appropriate values for a given param_name as specified in the table below will be returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetDeviceInfo<T3>(this ComputeDevice device, OpenTK.Compute.CL10.DeviceInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetDeviceInfo(device, param_name, param_value_size, ref param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Get information about an OpenCL device.
        /// </summary>
        /// <param name="device"> 
        /// Refers to the device returned by clGetDeviceIDs.
        /// </param>
        /// <param name="param_name"> 
        /// An enumeration constant that identifies the device information being queried. It can be one of the values as specified in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size in bytes must be greater than or equal to size of return type specified in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory location where appropriate values for a given param_name as specified in the table below will be returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data being queried by param_value. If param_value_size_ret is NULL, it is ignored
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetDeviceInfo<T3>(this ComputeDevice device, OpenTK.Compute.CL10.DeviceInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetDeviceInfo(device, param_name, param_value_size, ref param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Get the list of image formats supported by an OpenCL implementation.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object(s) will be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the List of supported cl_mem_flags values for clCreateBuffer
        /// </param>
        /// <param name="image_type"> 
        /// Describes the image type and must be either MemObjectImage2D or MemObjectImage3D.
        /// </param>
        /// <param name="num_entries"> 
        /// Specifies the number of entries that can be returned in the memory location given by image_formats.
        /// </param>
        /// <param name="image_formats"> 
        /// A pointer to a memory location where the list of supported image formats are returned. Each entry describes a cl_image_format structure supported by the OpenCL implementation. If image_formats is NULL, it is ignored.
        /// </param>
        /// <param name="num_image_formats"> 
        /// The actual number of supported image formats for a specific context and values specified by flags. If num_image_formats is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetSupportedImageFormats(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, OpenTK.Compute.CL10.MemObjectType image_type, Int32 num_entries, ImageFormat[] image_formats, Int32[] num_image_formats)
        {
            return CL.GetSupportedImageFormats(context, flags, image_type, num_entries, image_formats, num_image_formats);
        }

        /// <summary>[requires: v1.0]
        /// Get the list of image formats supported by an OpenCL implementation.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object(s) will be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the List of supported cl_mem_flags values for clCreateBuffer
        /// </param>
        /// <param name="image_type"> 
        /// Describes the image type and must be either MemObjectImage2D or MemObjectImage3D.
        /// </param>
        /// <param name="num_entries"> 
        /// Specifies the number of entries that can be returned in the memory location given by image_formats.
        /// </param>
        /// <param name="image_formats"> 
        /// A pointer to a memory location where the list of supported image formats are returned. Each entry describes a cl_image_format structure supported by the OpenCL implementation. If image_formats is NULL, it is ignored.
        /// </param>
        /// <param name="num_image_formats"> 
        /// The actual number of supported image formats for a specific context and values specified by flags. If num_image_formats is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetSupportedImageFormats(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, OpenTK.Compute.CL10.MemObjectType image_type, Int32 num_entries, ref ImageFormat image_formats, ref Int32 num_image_formats)
        {
            return CL.GetSupportedImageFormats(context, flags, image_type, num_entries, ref image_formats, ref num_image_formats);
        }

        /// <summary>[requires: v1.0]
        /// Get the list of image formats supported by an OpenCL implementation.
        /// </summary>
        /// <param name="context"> 
        /// A valid OpenCL context on which the image object(s) will be created.
        /// </param>
        /// <param name="flags"> 
        /// A bit-field that is used to specify allocation and usage information about the image memory object being created and is described in the List of supported cl_mem_flags values for clCreateBuffer
        /// </param>
        /// <param name="image_type"> 
        /// Describes the image type and must be either MemObjectImage2D or MemObjectImage3D.
        /// </param>
        /// <param name="num_entries"> 
        /// Specifies the number of entries that can be returned in the memory location given by image_formats.
        /// </param>
        /// <param name="image_formats"> 
        /// A pointer to a memory location where the list of supported image formats are returned. Each entry describes a cl_image_format structure supported by the OpenCL implementation. If image_formats is NULL, it is ignored.
        /// </param>
        /// <param name="num_image_formats"> 
        /// The actual number of supported image formats for a specific context and values specified by flags. If num_image_formats is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetSupportedImageFormats(this ComputeContext context, OpenTK.Compute.CL10.MemFlags flags, OpenTK.Compute.CL10.MemObjectType image_type, Int32 num_entries, ImageFormat* image_formats, Int32* num_image_formats)
        {
            return CL.GetSupportedImageFormats(context, flags, image_type, num_entries, image_formats, num_image_formats);
        }

        /// <summary>[requires: v1.0]
        /// Decrement the context reference count.
        /// </summary>
        /// <param name="context"> 
        /// The context to release.
        /// </param>
        public static ErrorCode ReleaseContext(this ComputeContext context)
        {
            return CL.ReleaseContext(context);
        }

        /// <summary>[requires: v1.0]
        /// Increment the context reference count.
        /// </summary>
        /// <param name="context"> 
        /// The context to retain.
        /// </param>
        public static ErrorCode RetainContext(this ComputeContext context)
        {
            return CL.RetainContext(context);
        }

    }

    /// <summary>
    /// Defines methods to simplify ComputeDevice usage.
    /// </summary>
    public partial struct ComputeDevice : IComparable<ComputeDevice>, IEquatable<ComputeDevice>
    {
        internal IntPtr Value;

        #region IComparable<ComputeDevice> Implementation

        /// <summary>
        /// Returns the sort order of the current instance compared to the specified <see cref="ComputeDevice"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputeDevice"/> to compare with the current <see cref="ComputeDevice"/>.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        public int CompareTo(ComputeDevice other)
        {
            int result = 0;
            if (result == 0)
                result = Value.CompareTo(other.Value);
            return result;
        }

        #endregion

        #region IEquatable<ComputeDevice> Implementation

        /// <summary>
        /// Determines whether the specified <see cref="ComputeDevice"/> is equal to the current <see cref="ComputeDevice"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputeDevice"/> to compare with the current <see cref="ComputeDevice"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputeDevice"/> is equal to the current
        /// <see cref="ComputeDevice"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(ComputeDevice other)
        {
            bool result = true;
            result &= Value.Equals(other.Value);
            return result;
        }

        #endregion

        #region Public Members

        /// <summary>Defines a zero (or null) <see cref="ComputeDevice"/></summary>
        public static readonly ComputeDevice Zero = new ComputeDevice();

        /// <summary>Tests two <see cref="ComputeDevice"/> instances for equality.</summary>
        public static bool operator ==(ComputeDevice left, ComputeDevice right)
        {
            return left.Equals(right);
        }

        /// <summary>Tests two <see cref="ComputeDevice"/> instances for inequality.</summary>
        public static bool operator !=(ComputeDevice left, ComputeDevice right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="ComputeDevice"/>.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with the current <see cref="ComputeDevice"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputeDevice"/> is equal to the current
        /// <see cref="ComputeDevice"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object other)
        {
            return other is ComputeDevice && Equals((ComputeDevice)other);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="ComputeDevice"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= Value.GetHashCode();
            return hash;
        }

        #endregion
    }

    /// <summary>
    /// Defines methods to simplify ComputeDevice usage.
    /// </summary>
    public static partial class ComputeDeviceExtensions
    {
        /// <summary>[requires: v1.0]
        /// Obtain the list of devices available on a platform.
        /// </summary>
        /// <param name="platform"> 
        /// Refers to the platform ID returned by clGetPlatformIDs or can be NULL. If platform is NULL, the behavior is implementation-defined.
        /// </param>
        /// <param name="device_type"> 
        /// A bitfield that identifies the type of OpenCL device. The device_type can be used to query specific OpenCL devices or all OpenCL devices available. The valid values for device_type are specified in the following table. cl_device_typeDescriptionDeviceTypeCpuAn OpenCL device that is the host processor. The host processor runs the OpenCL implementations and is a single or multi-core CPU.DeviceTypeGpuAn OpenCL device that is a GPU. By this we mean that the device can also be used to accelerate a 3D API such as OpenGL or DirectX.DeviceTypeAcceleratorDedicated OpenCL accelerators (for example the IBM CELL Blade). These devices communicate with the host processor using a peripheral interconnect such as PCIe.DeviceTypeDefaultThe default OpenCL device in the system.DeviceTypeAllAll OpenCL devices available in the system.
        /// </param>
        /// <param name="num_entries"> 
        /// The number of cl_device entries that can be added to devices. If devices is not NULL, the num_entries must be greater than zero.
        /// </param>
        /// <param name="devices"> 
        /// A list of OpenCL devices found. The cl_device_id values returned in devices can be used to identify a specific OpenCL device. If devices argument is NULL, this argument is ignored. The number of OpenCL devices returned is the mininum of the value specified by num_entries or the number of OpenCL devices whose type matches device_type.
        /// </param>
        /// <param name="num_devices"> 
        /// The number of OpenCL devices available that match device_type. If num_devices is NULL, this argument is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetDeviceIDs(this ComputePlatform platform, DeviceTypeFlags device_type, Int32 num_entries, ComputeDevice[] devices, [OutAttribute] out Int32 num_devices)
        {
            return CL.GetDeviceIDs(platform, device_type, num_entries, devices, out num_devices);
        }

        /// <summary>[requires: v1.0]
        /// Obtain the list of devices available on a platform.
        /// </summary>
        /// <param name="platform"> 
        /// Refers to the platform ID returned by clGetPlatformIDs or can be NULL. If platform is NULL, the behavior is implementation-defined.
        /// </param>
        /// <param name="device_type"> 
        /// A bitfield that identifies the type of OpenCL device. The device_type can be used to query specific OpenCL devices or all OpenCL devices available. The valid values for device_type are specified in the following table. cl_device_typeDescriptionDeviceTypeCpuAn OpenCL device that is the host processor. The host processor runs the OpenCL implementations and is a single or multi-core CPU.DeviceTypeGpuAn OpenCL device that is a GPU. By this we mean that the device can also be used to accelerate a 3D API such as OpenGL or DirectX.DeviceTypeAcceleratorDedicated OpenCL accelerators (for example the IBM CELL Blade). These devices communicate with the host processor using a peripheral interconnect such as PCIe.DeviceTypeDefaultThe default OpenCL device in the system.DeviceTypeAllAll OpenCL devices available in the system.
        /// </param>
        /// <param name="num_entries"> 
        /// The number of cl_device entries that can be added to devices. If devices is not NULL, the num_entries must be greater than zero.
        /// </param>
        /// <param name="devices"> 
        /// A list of OpenCL devices found. The cl_device_id values returned in devices can be used to identify a specific OpenCL device. If devices argument is NULL, this argument is ignored. The number of OpenCL devices returned is the mininum of the value specified by num_entries or the number of OpenCL devices whose type matches device_type.
        /// </param>
        /// <param name="num_devices"> 
        /// The number of OpenCL devices available that match device_type. If num_devices is NULL, this argument is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetDeviceIDs(this ComputePlatform platform, DeviceTypeFlags device_type, Int32 num_entries, ref ComputeDevice devices, [OutAttribute] out Int32 num_devices)
        {
            return CL.GetDeviceIDs(platform, device_type, num_entries, ref devices, out num_devices);
        }

        /// <summary>[requires: v1.0]
        /// Obtain the list of devices available on a platform.
        /// </summary>
        /// <param name="platform"> 
        /// Refers to the platform ID returned by clGetPlatformIDs or can be NULL. If platform is NULL, the behavior is implementation-defined.
        /// </param>
        /// <param name="device_type"> 
        /// A bitfield that identifies the type of OpenCL device. The device_type can be used to query specific OpenCL devices or all OpenCL devices available. The valid values for device_type are specified in the following table. cl_device_typeDescriptionDeviceTypeCpuAn OpenCL device that is the host processor. The host processor runs the OpenCL implementations and is a single or multi-core CPU.DeviceTypeGpuAn OpenCL device that is a GPU. By this we mean that the device can also be used to accelerate a 3D API such as OpenGL or DirectX.DeviceTypeAcceleratorDedicated OpenCL accelerators (for example the IBM CELL Blade). These devices communicate with the host processor using a peripheral interconnect such as PCIe.DeviceTypeDefaultThe default OpenCL device in the system.DeviceTypeAllAll OpenCL devices available in the system.
        /// </param>
        /// <param name="num_entries"> 
        /// The number of cl_device entries that can be added to devices. If devices is not NULL, the num_entries must be greater than zero.
        /// </param>
        /// <param name="devices"> 
        /// A list of OpenCL devices found. The cl_device_id values returned in devices can be used to identify a specific OpenCL device. If devices argument is NULL, this argument is ignored. The number of OpenCL devices returned is the mininum of the value specified by num_entries or the number of OpenCL devices whose type matches device_type.
        /// </param>
        /// <param name="num_devices"> 
        /// The number of OpenCL devices available that match device_type. If num_devices is NULL, this argument is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetDeviceIDs(this ComputePlatform platform, DeviceTypeFlags device_type, Int32 num_entries, ComputeDevice* devices, [OutAttribute] Int32* num_devices)
        {
            return CL.GetDeviceIDs(platform, device_type, num_entries, devices, num_devices);
        }

    }

    /// <summary>
    /// Defines methods to simplify ComputeEvent usage.
    /// </summary>
    public partial struct ComputeEvent : IComparable<ComputeEvent>, IEquatable<ComputeEvent>
    {
        internal IntPtr Value;

        #region IComparable<ComputeEvent> Implementation

        /// <summary>
        /// Returns the sort order of the current instance compared to the specified <see cref="ComputeEvent"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputeEvent"/> to compare with the current <see cref="ComputeEvent"/>.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        public int CompareTo(ComputeEvent other)
        {
            int result = 0;
            if (result == 0)
                result = Value.CompareTo(other.Value);
            return result;
        }

        #endregion

        #region IEquatable<ComputeEvent> Implementation

        /// <summary>
        /// Determines whether the specified <see cref="ComputeEvent"/> is equal to the current <see cref="ComputeEvent"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputeEvent"/> to compare with the current <see cref="ComputeEvent"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputeEvent"/> is equal to the current
        /// <see cref="ComputeEvent"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(ComputeEvent other)
        {
            bool result = true;
            result &= Value.Equals(other.Value);
            return result;
        }

        #endregion

        #region Public Members

        /// <summary>Defines a zero (or null) <see cref="ComputeEvent"/></summary>
        public static readonly ComputeEvent Zero = new ComputeEvent();

        /// <summary>Tests two <see cref="ComputeEvent"/> instances for equality.</summary>
        public static bool operator ==(ComputeEvent left, ComputeEvent right)
        {
            return left.Equals(right);
        }

        /// <summary>Tests two <see cref="ComputeEvent"/> instances for inequality.</summary>
        public static bool operator !=(ComputeEvent left, ComputeEvent right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="ComputeEvent"/>.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with the current <see cref="ComputeEvent"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputeEvent"/> is equal to the current
        /// <see cref="ComputeEvent"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object other)
        {
            return other is ComputeEvent && Equals((ComputeEvent)other);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="ComputeEvent"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= Value.GetHashCode();
            return hash;
        }

        /// <summary>[requires: v1.0]
        /// Waits on the host thread for commands identified by event objects to complete.
        /// </summary>
        /// <param name="num_events"> 
        /// The events specified in event_list act as synchronization points.
        /// </param>
        /// <param name="event_list"> 
        /// The events specified in event_list act as synchronization points.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode WaitForEvents(Int32 num_events, ComputeEvent[] event_list)
        {
            return CL.WaitForEvents(num_events, event_list);
        }

        /// <summary>[requires: v1.0]
        /// Waits on the host thread for commands identified by event objects to complete.
        /// </summary>
        /// <param name="num_events"> 
        /// The events specified in event_list act as synchronization points.
        /// </param>
        /// <param name="event_list"> 
        /// The events specified in event_list act as synchronization points.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode WaitForEvents(Int32 num_events, ref ComputeEvent event_list)
        {
            return CL.WaitForEvents(num_events, ref event_list);
        }

        /// <summary>[requires: v1.0]
        /// Waits on the host thread for commands identified by event objects to complete.
        /// </summary>
        /// <param name="num_events"> 
        /// The events specified in event_list act as synchronization points.
        /// </param>
        /// <param name="event_list"> 
        /// The events specified in event_list act as synchronization points.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode WaitForEvents(Int32 num_events, ComputeEvent* event_list)
        {
            return CL.WaitForEvents(num_events, event_list);
        }

        #endregion
    }

    /// <summary>
    /// Defines methods to simplify ComputeEvent usage.
    /// </summary>
    public static partial class ComputeEventExtensions
    {
        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventInfo(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] IntPtr[] param_value_size_ret)
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventInfo(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] out IntPtr param_value_size_ret)
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetEventInfo(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] IntPtr* param_value_size_ret)
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetEventInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetEventInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetEventInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, ref param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, ref param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the event object.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetEventInfo is described in the table below: cl_event_infoReturn TypeInformation returned in param_valueEventCommandQueuecl_command_queue Return the command-queue associated with event. EventCommandTypecl_command_typeReturn the command associated with event. Can be one of the following values: CL_COMMAND_NDRANGE_KERNEL CL_COMMAND_TASK CL_COMMAND_NATIVE_KERNEL CL_COMMAND_READ_BUFFER CL_COMMAND_WRITE_BUFFER CL_COMMAND_COPY_BUFFER CL_COMMAND_READ_IMAGE CL_COMMAND_WRITE_IMAGE CL_COMMAND_COPY_IMAGE CL_COMMAND_COPY_BUFFER_TO_IMAGE CL_COMMAND_COPY_IMAGE_TO_BUFFER CL_COMMAND_MAP_BUFFER CL_COMMAND_MAP_IMAGE CL_COMMAND_UNMAP_MEM_OBJECT CL_COMMAND_MARKER CL_COMMAND_ACQUIRE_GL_OBJECTS CL_COMMAND_RELEASE_GL_OBJECTSEventCommand executionStatuscl_int Return the execution status of the command identified by event. The valid values are: CL_QUEUED (command has been enqueued in the command-queue),CL_SUBMITTED (enqueued command has been submitted by the host to the device associated with the command-queue),CL_RUNNING (device is currently executing this command),CL_COMPLETE (the command has completed), orError code given by a negative integer value. (command was abnormally terminated – this may be caused by a bad memory access etc.)EventReferenceCountcl_uint Return the event reference count. The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of the return type as described in the table below.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetEventInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.EventInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventInfo(@event, param_name, param_value_size, ref param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventProfilingInfo(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] IntPtr[] param_value_size_ret)
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventProfilingInfo(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] out IntPtr param_value_size_ret)
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetEventProfilingInfo(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] IntPtr* param_value_size_ret)
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventProfilingInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventProfilingInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetEventProfilingInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventProfilingInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventProfilingInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetEventProfilingInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventProfilingInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventProfilingInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetEventProfilingInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventProfilingInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, ref param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetEventProfilingInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, ref param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns profiling information for the command associated with event if profiling is enabled.
        /// </summary>
        /// <param name="event"> 
        /// Specifies the event object.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the profiling data to query. The list of supported param_name types and the information returned in param_value by clGetEventProfilingInfo is described in the table of parameter queries below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table bolow.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetEventProfilingInfo<T3>(this ComputeEvent @event, OpenTK.Compute.CL10.ProfilingInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetEventProfilingInfo(@event, param_name, param_value_size, ref param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Decrements the event reference count.
        /// </summary>
        /// <param name="event"> 
        /// Event object being released.
        /// </param>
        public static ErrorCode ReleaseEvent(this ComputeEvent @event)
        {
            return CL.ReleaseEvent(@event);
        }

        /// <summary>[requires: v1.0]
        /// Increments the event reference count.
        /// </summary>
        /// <param name="event"> 
        /// Event object being retained.
        /// </param>
        public static Int32 RetainEvent(this ComputeEvent @event)
        {
            return CL.RetainEvent(@event);
        }

    }

    /// <summary>
    /// Defines methods to simplify ComputeKernel usage.
    /// </summary>
    public partial struct ComputeKernel : IComparable<ComputeKernel>, IEquatable<ComputeKernel>
    {
        internal IntPtr Value;

        #region IComparable<ComputeKernel> Implementation

        /// <summary>
        /// Returns the sort order of the current instance compared to the specified <see cref="ComputeKernel"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputeKernel"/> to compare with the current <see cref="ComputeKernel"/>.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        public int CompareTo(ComputeKernel other)
        {
            int result = 0;
            if (result == 0)
                result = Value.CompareTo(other.Value);
            return result;
        }

        #endregion

        #region IEquatable<ComputeKernel> Implementation

        /// <summary>
        /// Determines whether the specified <see cref="ComputeKernel"/> is equal to the current <see cref="ComputeKernel"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputeKernel"/> to compare with the current <see cref="ComputeKernel"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputeKernel"/> is equal to the current
        /// <see cref="ComputeKernel"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(ComputeKernel other)
        {
            bool result = true;
            result &= Value.Equals(other.Value);
            return result;
        }

        #endregion

        #region Public Members

        /// <summary>Defines a zero (or null) <see cref="ComputeKernel"/></summary>
        public static readonly ComputeKernel Zero = new ComputeKernel();

        /// <summary>Tests two <see cref="ComputeKernel"/> instances for equality.</summary>
        public static bool operator ==(ComputeKernel left, ComputeKernel right)
        {
            return left.Equals(right);
        }

        /// <summary>Tests two <see cref="ComputeKernel"/> instances for inequality.</summary>
        public static bool operator !=(ComputeKernel left, ComputeKernel right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="ComputeKernel"/>.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with the current <see cref="ComputeKernel"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputeKernel"/> is equal to the current
        /// <see cref="ComputeKernel"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object other)
        {
            return other is ComputeKernel && Equals((ComputeKernel)other);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="ComputeKernel"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= Value.GetHashCode();
            return hash;
        }

        #endregion
    }

    /// <summary>
    /// Defines methods to simplify ComputeKernel usage.
    /// </summary>
    public static partial class ComputeKernelExtensions
    {
        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelInfo(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] IntPtr[] param_value_size_ret)
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelInfo(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] out IntPtr param_value_size_ret)
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetKernelInfo(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] IntPtr* param_value_size_ret)
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelInfo<T3>(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelInfo<T3>(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetKernelInfo<T3>(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelInfo<T3>(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelInfo<T3>(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetKernelInfo<T3>(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelInfo<T3>(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelInfo<T3>(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetKernelInfo<T3>(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T3[,,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelInfo<T3>(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, ref param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelInfo<T3>(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, ref param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_infoReturn TypeInfo. returned in param_valueKernelFunctionNamechar[] Return the kernel function name. KernelNumArgscl_uint Return the number of arguments to kernel. KernelReferenceCountcl_uint Return the kernel reference count.  The reference count returned should be considered immediately stale. It is unsuitable for general use in applications. This feature is provided for identifying memory leaks. KernelContextcl_context Return the context associated with kernel. KernelProgramcl_program Return the program object associated with kernel.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetKernelInfo<T3>(this ComputeKernel kernel, OpenTK.Compute.CL10.KernelInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T3 param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T3 : struct
        
        {
            return CL.GetKernelInfo(kernel, param_name, param_value_size, ref param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelWorkGroupInfo(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] IntPtr[] param_value_size_ret)
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelWorkGroupInfo(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] out IntPtr param_value_size_ret)
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetKernelWorkGroupInfo(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] IntPtr* param_value_size_ret)
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelWorkGroupInfo<T4>(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelWorkGroupInfo<T4>(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetKernelWorkGroupInfo<T4>(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelWorkGroupInfo<T4>(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[,] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelWorkGroupInfo<T4>(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetKernelWorkGroupInfo<T4>(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelWorkGroupInfo<T4>(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[,,] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelWorkGroupInfo<T4>(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[,,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetKernelWorkGroupInfo<T4>(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[,,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelWorkGroupInfo<T4>(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T4 param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, ref param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetKernelWorkGroupInfo<T4>(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T4 param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, ref param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns information about the kernel object that may be specific to a device.
        /// </summary>
        /// <param name="kernel"> 
        /// Specifies the kernel object being queried.
        /// </param>
        /// <param name="device"> 
        /// Identifies a specific device in the list of devices associated with kernel. The list of devices is the list of devices in the OpenCL context that is associated with kernel. If the list of devices associated with kernel is a single device, device can be a NULL value.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetKernelWorkGroupInfo is described in the table below.
        /// </param>
        /// <param name="param_value_size"> 
        /// Used to specify the size in bytes of memory pointed to by param_value. This size must be greater than or equal to size of return type as described in the table below. cl_kernel_work_group_infoReturn TypeInfo. returned in param_valueKernelWorkGroupSizesize_t This provides a mechanism for the application to query the work-group size that can be used to execute a kernel on a specific device given by device. The OpenCL implementation uses the resource requirements of the kernel (register usage etc.) to determine what this work-group size should be. KernelCompileWorkGroupSizesize_t[3] Returns the work-group size specified by the Attribute((reqdWorkGr oupSize(x, y, z))) qualifier. See Function Qualifiers. If the work-group size is not specified using the above attribute qualifier (0, 0, 0) is returned. KernelLocalMemSizecl_ulong Returns the amount of local memory in bytes being used by a kernel. This includes local memory that may be needed by an implementation to execute the kernel, variables declared inside the kernel with the __local address qualifier and local memory to be allocated for arguments to the kernel declared as pointers with the __local address qualifier and whose size is specified with clSetKernelArg.  If the local memory size, for any pointer argument to the kernel declared with the __local address qualifier, is not specified, its size is assumed to be 0.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetKernelWorkGroupInfo<T4>(this ComputeKernel kernel, ComputeDevice device, OpenTK.Compute.CL10.KernelWorkGroupInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T4 param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetKernelWorkGroupInfo(kernel, device, param_name, param_value_size, ref param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Decrements the kernel reference count.
        /// </summary>
        /// <param name="kernel"></param>
        public static ErrorCode ReleaseKernel(this ComputeKernel kernel)
        {
            return CL.ReleaseKernel(kernel);
        }

        /// <summary>[requires: v1.0]
        /// Increments the program program reference count.
        /// </summary>
        /// <param name="kernel"></param>
        public static ErrorCode RetainKernel(this ComputeKernel kernel)
        {
            return CL.RetainKernel(kernel);
        }

        /// <summary>[requires: v1.0]
        /// Used to set the argument value for a specific argument of a kernel.
        /// </summary>
        /// <param name="kernel"> 
        /// A valid kernel object.
        /// </param>
        /// <param name="arg_index"> 
        /// The argument index. Arguments to the kernel are referred by indices that go from 0 for the leftmost argument to n - 1, where n is the total number of arguments declared by a kernel.
        /// </param>
        /// <param name="arg_size"> 
        /// Specifies the size of the argument value. If the argument is a memory object, the size is the size of the buffer or image object type. For arguments declared with the __local qualifier, the size specified will be the size in bytes of the buffer that must be allocated for the __local argument. If the argument is of type sampler_t, the arg_size value must be equal to sizeof(cl_sampler). For all other arguments, the size will be the size of argument type.
        /// </param>
        /// <param name="arg_value"> 
        /// A pointer to data that should be used as the argument value for argument specified by arg_index. The argument data pointed to by arg_value is copied and the arg_value pointer can therefore be reused by the application after clSetKernelArg returns. The argument value specified is the value used by all API calls that enqueue kernel (clEnqueueNDRangeKernel and clEnqueueTask) until the argument value is changed by a call to clSetKernelArg for kernel.  If the argument is a memory object (buffer or image), the arg_value entry will be a pointer to the appropriate buffer or image object. The memory object must be created with the context associated with the kernel object. A NULL value can also be specified if the argument is a buffer object in which case a NULL value will be used as the value for the argument declared as a pointer to __global or __constant memory in the kernel. If the argument is declared with the __local qualifier, the arg_value entry must be NULL. If the argument is of type sampler_t, the arg_value entry must be a pointer to the sampler object. For all other kernel arguments, the arg_value entry must be a pointer to the actual data to be used as argument value.  The memory object specified as argument value must be a buffer object (or NULL) if the argument is declared to be a pointer of a built-in or user defined type with the __global or __constant qualifier. If the argument is declared with the __constant qualifier, the size in bytes of the memory object cannot exceed DeviceMaxConstantBufferSize and the number of arguments declared with the __constant qualifier cannot exceed DeviceMaxConstantArgs.  The memory object specified as argument value must be a 2D image object if the argument is declared to be of type image2d_t. The memory object specified as argument value must be a 3D image object if argument is declared to be of type image3d_t.
        /// </param>
        public static ErrorCode SetKernelArg(this ComputeKernel kernel, Int32 arg_index, IntPtr arg_size, IntPtr arg_value)
        {
            return CL.SetKernelArg(kernel, arg_index, arg_size, arg_value);
        }

        /// <summary>[requires: v1.0]
        /// Used to set the argument value for a specific argument of a kernel.
        /// </summary>
        /// <param name="kernel"> 
        /// A valid kernel object.
        /// </param>
        /// <param name="arg_index"> 
        /// The argument index. Arguments to the kernel are referred by indices that go from 0 for the leftmost argument to n - 1, where n is the total number of arguments declared by a kernel.
        /// </param>
        /// <param name="arg_size"> 
        /// Specifies the size of the argument value. If the argument is a memory object, the size is the size of the buffer or image object type. For arguments declared with the __local qualifier, the size specified will be the size in bytes of the buffer that must be allocated for the __local argument. If the argument is of type sampler_t, the arg_size value must be equal to sizeof(cl_sampler). For all other arguments, the size will be the size of argument type.
        /// </param>
        /// <param name="arg_value"> 
        /// A pointer to data that should be used as the argument value for argument specified by arg_index. The argument data pointed to by arg_value is copied and the arg_value pointer can therefore be reused by the application after clSetKernelArg returns. The argument value specified is the value used by all API calls that enqueue kernel (clEnqueueNDRangeKernel and clEnqueueTask) until the argument value is changed by a call to clSetKernelArg for kernel.  If the argument is a memory object (buffer or image), the arg_value entry will be a pointer to the appropriate buffer or image object. The memory object must be created with the context associated with the kernel object. A NULL value can also be specified if the argument is a buffer object in which case a NULL value will be used as the value for the argument declared as a pointer to __global or __constant memory in the kernel. If the argument is declared with the __local qualifier, the arg_value entry must be NULL. If the argument is of type sampler_t, the arg_value entry must be a pointer to the sampler object. For all other kernel arguments, the arg_value entry must be a pointer to the actual data to be used as argument value.  The memory object specified as argument value must be a buffer object (or NULL) if the argument is declared to be a pointer of a built-in or user defined type with the __global or __constant qualifier. If the argument is declared with the __constant qualifier, the size in bytes of the memory object cannot exceed DeviceMaxConstantBufferSize and the number of arguments declared with the __constant qualifier cannot exceed DeviceMaxConstantArgs.  The memory object specified as argument value must be a 2D image object if the argument is declared to be of type image2d_t. The memory object specified as argument value must be a 3D image object if argument is declared to be of type image3d_t.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode SetKernelArg<T3>(this ComputeKernel kernel, Int32 arg_index, IntPtr arg_size, [InAttribute, OutAttribute] T3[] arg_value)
            where T3 : struct
        
        {
            return CL.SetKernelArg(kernel, arg_index, arg_size, arg_value);
        }

        /// <summary>[requires: v1.0]
        /// Used to set the argument value for a specific argument of a kernel.
        /// </summary>
        /// <param name="kernel"> 
        /// A valid kernel object.
        /// </param>
        /// <param name="arg_index"> 
        /// The argument index. Arguments to the kernel are referred by indices that go from 0 for the leftmost argument to n - 1, where n is the total number of arguments declared by a kernel.
        /// </param>
        /// <param name="arg_size"> 
        /// Specifies the size of the argument value. If the argument is a memory object, the size is the size of the buffer or image object type. For arguments declared with the __local qualifier, the size specified will be the size in bytes of the buffer that must be allocated for the __local argument. If the argument is of type sampler_t, the arg_size value must be equal to sizeof(cl_sampler). For all other arguments, the size will be the size of argument type.
        /// </param>
        /// <param name="arg_value"> 
        /// A pointer to data that should be used as the argument value for argument specified by arg_index. The argument data pointed to by arg_value is copied and the arg_value pointer can therefore be reused by the application after clSetKernelArg returns. The argument value specified is the value used by all API calls that enqueue kernel (clEnqueueNDRangeKernel and clEnqueueTask) until the argument value is changed by a call to clSetKernelArg for kernel.  If the argument is a memory object (buffer or image), the arg_value entry will be a pointer to the appropriate buffer or image object. The memory object must be created with the context associated with the kernel object. A NULL value can also be specified if the argument is a buffer object in which case a NULL value will be used as the value for the argument declared as a pointer to __global or __constant memory in the kernel. If the argument is declared with the __local qualifier, the arg_value entry must be NULL. If the argument is of type sampler_t, the arg_value entry must be a pointer to the sampler object. For all other kernel arguments, the arg_value entry must be a pointer to the actual data to be used as argument value.  The memory object specified as argument value must be a buffer object (or NULL) if the argument is declared to be a pointer of a built-in or user defined type with the __global or __constant qualifier. If the argument is declared with the __constant qualifier, the size in bytes of the memory object cannot exceed DeviceMaxConstantBufferSize and the number of arguments declared with the __constant qualifier cannot exceed DeviceMaxConstantArgs.  The memory object specified as argument value must be a 2D image object if the argument is declared to be of type image2d_t. The memory object specified as argument value must be a 3D image object if argument is declared to be of type image3d_t.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode SetKernelArg<T3>(this ComputeKernel kernel, Int32 arg_index, IntPtr arg_size, [InAttribute, OutAttribute] T3[,] arg_value)
            where T3 : struct
        
        {
            return CL.SetKernelArg(kernel, arg_index, arg_size, arg_value);
        }

        /// <summary>[requires: v1.0]
        /// Used to set the argument value for a specific argument of a kernel.
        /// </summary>
        /// <param name="kernel"> 
        /// A valid kernel object.
        /// </param>
        /// <param name="arg_index"> 
        /// The argument index. Arguments to the kernel are referred by indices that go from 0 for the leftmost argument to n - 1, where n is the total number of arguments declared by a kernel.
        /// </param>
        /// <param name="arg_size"> 
        /// Specifies the size of the argument value. If the argument is a memory object, the size is the size of the buffer or image object type. For arguments declared with the __local qualifier, the size specified will be the size in bytes of the buffer that must be allocated for the __local argument. If the argument is of type sampler_t, the arg_size value must be equal to sizeof(cl_sampler). For all other arguments, the size will be the size of argument type.
        /// </param>
        /// <param name="arg_value"> 
        /// A pointer to data that should be used as the argument value for argument specified by arg_index. The argument data pointed to by arg_value is copied and the arg_value pointer can therefore be reused by the application after clSetKernelArg returns. The argument value specified is the value used by all API calls that enqueue kernel (clEnqueueNDRangeKernel and clEnqueueTask) until the argument value is changed by a call to clSetKernelArg for kernel.  If the argument is a memory object (buffer or image), the arg_value entry will be a pointer to the appropriate buffer or image object. The memory object must be created with the context associated with the kernel object. A NULL value can also be specified if the argument is a buffer object in which case a NULL value will be used as the value for the argument declared as a pointer to __global or __constant memory in the kernel. If the argument is declared with the __local qualifier, the arg_value entry must be NULL. If the argument is of type sampler_t, the arg_value entry must be a pointer to the sampler object. For all other kernel arguments, the arg_value entry must be a pointer to the actual data to be used as argument value.  The memory object specified as argument value must be a buffer object (or NULL) if the argument is declared to be a pointer of a built-in or user defined type with the __global or __constant qualifier. If the argument is declared with the __constant qualifier, the size in bytes of the memory object cannot exceed DeviceMaxConstantBufferSize and the number of arguments declared with the __constant qualifier cannot exceed DeviceMaxConstantArgs.  The memory object specified as argument value must be a 2D image object if the argument is declared to be of type image2d_t. The memory object specified as argument value must be a 3D image object if argument is declared to be of type image3d_t.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode SetKernelArg<T3>(this ComputeKernel kernel, Int32 arg_index, IntPtr arg_size, [InAttribute, OutAttribute] T3[,,] arg_value)
            where T3 : struct
        
        {
            return CL.SetKernelArg(kernel, arg_index, arg_size, arg_value);
        }

        /// <summary>[requires: v1.0]
        /// Used to set the argument value for a specific argument of a kernel.
        /// </summary>
        /// <param name="kernel"> 
        /// A valid kernel object.
        /// </param>
        /// <param name="arg_index"> 
        /// The argument index. Arguments to the kernel are referred by indices that go from 0 for the leftmost argument to n - 1, where n is the total number of arguments declared by a kernel.
        /// </param>
        /// <param name="arg_size"> 
        /// Specifies the size of the argument value. If the argument is a memory object, the size is the size of the buffer or image object type. For arguments declared with the __local qualifier, the size specified will be the size in bytes of the buffer that must be allocated for the __local argument. If the argument is of type sampler_t, the arg_size value must be equal to sizeof(cl_sampler). For all other arguments, the size will be the size of argument type.
        /// </param>
        /// <param name="arg_value"> 
        /// A pointer to data that should be used as the argument value for argument specified by arg_index. The argument data pointed to by arg_value is copied and the arg_value pointer can therefore be reused by the application after clSetKernelArg returns. The argument value specified is the value used by all API calls that enqueue kernel (clEnqueueNDRangeKernel and clEnqueueTask) until the argument value is changed by a call to clSetKernelArg for kernel.  If the argument is a memory object (buffer or image), the arg_value entry will be a pointer to the appropriate buffer or image object. The memory object must be created with the context associated with the kernel object. A NULL value can also be specified if the argument is a buffer object in which case a NULL value will be used as the value for the argument declared as a pointer to __global or __constant memory in the kernel. If the argument is declared with the __local qualifier, the arg_value entry must be NULL. If the argument is of type sampler_t, the arg_value entry must be a pointer to the sampler object. For all other kernel arguments, the arg_value entry must be a pointer to the actual data to be used as argument value.  The memory object specified as argument value must be a buffer object (or NULL) if the argument is declared to be a pointer of a built-in or user defined type with the __global or __constant qualifier. If the argument is declared with the __constant qualifier, the size in bytes of the memory object cannot exceed DeviceMaxConstantBufferSize and the number of arguments declared with the __constant qualifier cannot exceed DeviceMaxConstantArgs.  The memory object specified as argument value must be a 2D image object if the argument is declared to be of type image2d_t. The memory object specified as argument value must be a 3D image object if argument is declared to be of type image3d_t.
        /// </param>
        public static ErrorCode SetKernelArg<T3>(this ComputeKernel kernel, Int32 arg_index, IntPtr arg_size, [InAttribute, OutAttribute] ref T3 arg_value)
            where T3 : struct
        
        {
            return CL.SetKernelArg(kernel, arg_index, arg_size, ref arg_value);
        }

    }

    /// <summary>
    /// Defines methods to simplify ComputeMemory usage.
    /// </summary>
    public partial struct ComputeMemory : IComparable<ComputeMemory>, IEquatable<ComputeMemory>
    {
        internal IntPtr Value;

        #region IComparable<ComputeMemory> Implementation

        /// <summary>
        /// Returns the sort order of the current instance compared to the specified <see cref="ComputeMemory"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputeMemory"/> to compare with the current <see cref="ComputeMemory"/>.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        public int CompareTo(ComputeMemory other)
        {
            int result = 0;
            if (result == 0)
                result = Value.CompareTo(other.Value);
            return result;
        }

        #endregion

        #region IEquatable<ComputeMemory> Implementation

        /// <summary>
        /// Determines whether the specified <see cref="ComputeMemory"/> is equal to the current <see cref="ComputeMemory"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputeMemory"/> to compare with the current <see cref="ComputeMemory"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputeMemory"/> is equal to the current
        /// <see cref="ComputeMemory"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(ComputeMemory other)
        {
            bool result = true;
            result &= Value.Equals(other.Value);
            return result;
        }

        #endregion

        #region Public Members

        /// <summary>Defines a zero (or null) <see cref="ComputeMemory"/></summary>
        public static readonly ComputeMemory Zero = new ComputeMemory();

        /// <summary>Tests two <see cref="ComputeMemory"/> instances for equality.</summary>
        public static bool operator ==(ComputeMemory left, ComputeMemory right)
        {
            return left.Equals(right);
        }

        /// <summary>Tests two <see cref="ComputeMemory"/> instances for inequality.</summary>
        public static bool operator !=(ComputeMemory left, ComputeMemory right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="ComputeMemory"/>.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with the current <see cref="ComputeMemory"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputeMemory"/> is equal to the current
        /// <see cref="ComputeMemory"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object other)
        {
            return other is ComputeMemory && Equals((ComputeMemory)other);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="ComputeMemory"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= Value.GetHashCode();
            return hash;
        }

        #endregion
    }

    /// <summary>
    /// Defines methods to simplify ComputeMemory usage.
    /// </summary>
    public static partial class ComputeMemoryExtensions
    {
        /// <summary>[requires: v1.0]
        /// Decrements the memory object reference count.
        /// </summary>
        /// <param name="memobj"></param>
        public static ErrorCode ReleaseMemObject(this ComputeMemory memobj)
        {
            return CL.ReleaseMemObject(memobj);
        }

    }

    /// <summary>
    /// Defines methods to simplify ComputePlatform usage.
    /// </summary>
    public partial struct ComputePlatform : IComparable<ComputePlatform>, IEquatable<ComputePlatform>
    {
        internal IntPtr Value;

        #region IComparable<ComputePlatform> Implementation

        /// <summary>
        /// Returns the sort order of the current instance compared to the specified <see cref="ComputePlatform"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputePlatform"/> to compare with the current <see cref="ComputePlatform"/>.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        public int CompareTo(ComputePlatform other)
        {
            int result = 0;
            if (result == 0)
                result = Value.CompareTo(other.Value);
            return result;
        }

        #endregion

        #region IEquatable<ComputePlatform> Implementation

        /// <summary>
        /// Determines whether the specified <see cref="ComputePlatform"/> is equal to the current <see cref="ComputePlatform"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputePlatform"/> to compare with the current <see cref="ComputePlatform"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputePlatform"/> is equal to the current
        /// <see cref="ComputePlatform"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(ComputePlatform other)
        {
            bool result = true;
            result &= Value.Equals(other.Value);
            return result;
        }

        #endregion

        #region Public Members

        /// <summary>Defines a zero (or null) <see cref="ComputePlatform"/></summary>
        public static readonly ComputePlatform Zero = new ComputePlatform();

        /// <summary>Tests two <see cref="ComputePlatform"/> instances for equality.</summary>
        public static bool operator ==(ComputePlatform left, ComputePlatform right)
        {
            return left.Equals(right);
        }

        /// <summary>Tests two <see cref="ComputePlatform"/> instances for inequality.</summary>
        public static bool operator !=(ComputePlatform left, ComputePlatform right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="ComputePlatform"/>.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with the current <see cref="ComputePlatform"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputePlatform"/> is equal to the current
        /// <see cref="ComputePlatform"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object other)
        {
            return other is ComputePlatform && Equals((ComputePlatform)other);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="ComputePlatform"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= Value.GetHashCode();
            return hash;
        }

        /// <summary>[requires: v1.0]
        /// Obtain the list of platforms available.
        /// </summary>
        /// <param name="num_entries"> 
        /// The number of cl_platform_id entries that can be added to platforms. If platforms is not NULL, the num_entries must be greater than zero.
        /// </param>
        /// <param name="platforms"> 
        /// Returns a list of OpenCL platforms found. The cl_platform_id values returned in platforms can be used to identify a specific OpenCL platform. If platforms argument is NULL, this argument is ignored. The number of OpenCL platforms returned is the mininum of the value specified by num_entries or the number of OpenCL platforms available.
        /// </param>
        /// <param name="num_platforms"> 
        /// Returns the number of OpenCL platforms available. If num_platforms is NULL, this argument is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetPlatformIDs(Int32 num_entries, ComputePlatform[] platforms, [OutAttribute] out Int32 num_platforms)
        {
            return CL.GetPlatformIDs(num_entries, platforms, out num_platforms);
        }

        /// <summary>[requires: v1.0]
        /// Obtain the list of platforms available.
        /// </summary>
        /// <param name="num_entries"> 
        /// The number of cl_platform_id entries that can be added to platforms. If platforms is not NULL, the num_entries must be greater than zero.
        /// </param>
        /// <param name="platforms"> 
        /// Returns a list of OpenCL platforms found. The cl_platform_id values returned in platforms can be used to identify a specific OpenCL platform. If platforms argument is NULL, this argument is ignored. The number of OpenCL platforms returned is the mininum of the value specified by num_entries or the number of OpenCL platforms available.
        /// </param>
        /// <param name="num_platforms"> 
        /// Returns the number of OpenCL platforms available. If num_platforms is NULL, this argument is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetPlatformIDs(Int32 num_entries, ref ComputePlatform platforms, [OutAttribute] out Int32 num_platforms)
        {
            return CL.GetPlatformIDs(num_entries, ref platforms, out num_platforms);
        }

        /// <summary>[requires: v1.0]
        /// Obtain the list of platforms available.
        /// </summary>
        /// <param name="num_entries"> 
        /// The number of cl_platform_id entries that can be added to platforms. If platforms is not NULL, the num_entries must be greater than zero.
        /// </param>
        /// <param name="platforms"> 
        /// Returns a list of OpenCL platforms found. The cl_platform_id values returned in platforms can be used to identify a specific OpenCL platform. If platforms argument is NULL, this argument is ignored. The number of OpenCL platforms returned is the mininum of the value specified by num_entries or the number of OpenCL platforms available.
        /// </param>
        /// <param name="num_platforms"> 
        /// Returns the number of OpenCL platforms available. If num_platforms is NULL, this argument is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetPlatformIDs(Int32 num_entries, ComputePlatform* platforms, [OutAttribute] Int32* num_platforms)
        {
            return CL.GetPlatformIDs(num_entries, platforms, num_platforms);
        }

        #endregion
    }

    /// <summary>
    /// Defines methods to simplify ComputePlatform usage.
    /// </summary>
    public static partial class ComputePlatformExtensions
    {
    }

    /// <summary>
    /// Defines methods to simplify ComputeProgram usage.
    /// </summary>
    public partial struct ComputeProgram : IComparable<ComputeProgram>, IEquatable<ComputeProgram>
    {
        internal IntPtr Value;

        #region IComparable<ComputeProgram> Implementation

        /// <summary>
        /// Returns the sort order of the current instance compared to the specified <see cref="ComputeProgram"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputeProgram"/> to compare with the current <see cref="ComputeProgram"/>.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        public int CompareTo(ComputeProgram other)
        {
            int result = 0;
            if (result == 0)
                result = Value.CompareTo(other.Value);
            return result;
        }

        #endregion

        #region IEquatable<ComputeProgram> Implementation

        /// <summary>
        /// Determines whether the specified <see cref="ComputeProgram"/> is equal to the current <see cref="ComputeProgram"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputeProgram"/> to compare with the current <see cref="ComputeProgram"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputeProgram"/> is equal to the current
        /// <see cref="ComputeProgram"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(ComputeProgram other)
        {
            bool result = true;
            result &= Value.Equals(other.Value);
            return result;
        }

        #endregion

        #region Public Members

        /// <summary>Defines a zero (or null) <see cref="ComputeProgram"/></summary>
        public static readonly ComputeProgram Zero = new ComputeProgram();

        /// <summary>Tests two <see cref="ComputeProgram"/> instances for equality.</summary>
        public static bool operator ==(ComputeProgram left, ComputeProgram right)
        {
            return left.Equals(right);
        }

        /// <summary>Tests two <see cref="ComputeProgram"/> instances for inequality.</summary>
        public static bool operator !=(ComputeProgram left, ComputeProgram right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="ComputeProgram"/>.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with the current <see cref="ComputeProgram"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputeProgram"/> is equal to the current
        /// <see cref="ComputeProgram"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object other)
        {
            return other is ComputeProgram && Equals((ComputeProgram)other);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="ComputeProgram"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= Value.GetHashCode();
            return hash;
        }

        #endregion
    }

    /// <summary>
    /// Defines methods to simplify ComputeProgram usage.
    /// </summary>
    public static partial class ComputeProgramExtensions
    {
        /// <summary>[requires: v1.0]
        /// Builds (compiles and links) a program executable from the program source or binary.
        /// </summary>
        /// <param name="program"> 
        /// The program object
        /// </param>
        /// <param name="num_devices"> 
        /// The number of devices listed in device_list.
        /// </param>
        /// <param name="device_list"> 
        /// A pointer to a list of devices that are in program. If device_list is NULL value, the program executable is built for all devices associated with program for which a source or binary has been loaded. If device_list is a non-NULL value, the program executable is built for devices specified in this list for which a source or binary has been loaded.
        /// </param>
        /// <param name="options"> 
        /// A pointer to a string that describes the build options to be used for building the program executable. The list of supported options is described in "Build Options" below.
        /// </param>
        /// <param name="pfn_notify"> 
        /// A function pointer to a notification routine. The notification routine is a callback function that an application can register and which will be called when the program executable has been built (successfully or unsuccessfully). If pfn_notify is not NULL, clBuildProgram does not need to wait for the build to complete and can return immediately. If pfn_notify is NULL, clBuildProgram does not return until the build has completed. This callback function may be called asynchronously by the OpenCL implementation. It is the application's responsibility to ensure that the callback function is thread-safe.
        /// </param>
        /// <param name="user_data"> 
        /// Passed as an argument when pfn_notify is called. user_data can be NULL.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode BuildProgram(this ComputeProgram program, Int32 num_devices, ComputeDevice[] device_list, String options, ProgramNotifyDelegate pfn_notify, IntPtr user_data)
        {
            return CL.BuildProgram(program, num_devices, device_list, options, pfn_notify, user_data);
        }

        /// <summary>[requires: v1.0]
        /// Builds (compiles and links) a program executable from the program source or binary.
        /// </summary>
        /// <param name="program"> 
        /// The program object
        /// </param>
        /// <param name="num_devices"> 
        /// The number of devices listed in device_list.
        /// </param>
        /// <param name="device_list"> 
        /// A pointer to a list of devices that are in program. If device_list is NULL value, the program executable is built for all devices associated with program for which a source or binary has been loaded. If device_list is a non-NULL value, the program executable is built for devices specified in this list for which a source or binary has been loaded.
        /// </param>
        /// <param name="options"> 
        /// A pointer to a string that describes the build options to be used for building the program executable. The list of supported options is described in "Build Options" below.
        /// </param>
        /// <param name="pfn_notify"> 
        /// A function pointer to a notification routine. The notification routine is a callback function that an application can register and which will be called when the program executable has been built (successfully or unsuccessfully). If pfn_notify is not NULL, clBuildProgram does not need to wait for the build to complete and can return immediately. If pfn_notify is NULL, clBuildProgram does not return until the build has completed. This callback function may be called asynchronously by the OpenCL implementation. It is the application's responsibility to ensure that the callback function is thread-safe.
        /// </param>
        /// <param name="user_data"> 
        /// Passed as an argument when pfn_notify is called. user_data can be NULL.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode BuildProgram(this ComputeProgram program, Int32 num_devices, ref ComputeDevice device_list, String options, ProgramNotifyDelegate pfn_notify, IntPtr user_data)
        {
            return CL.BuildProgram(program, num_devices, ref device_list, options, pfn_notify, user_data);
        }

        /// <summary>[requires: v1.0]
        /// Builds (compiles and links) a program executable from the program source or binary.
        /// </summary>
        /// <param name="program"> 
        /// The program object
        /// </param>
        /// <param name="num_devices"> 
        /// The number of devices listed in device_list.
        /// </param>
        /// <param name="device_list"> 
        /// A pointer to a list of devices that are in program. If device_list is NULL value, the program executable is built for all devices associated with program for which a source or binary has been loaded. If device_list is a non-NULL value, the program executable is built for devices specified in this list for which a source or binary has been loaded.
        /// </param>
        /// <param name="options"> 
        /// A pointer to a string that describes the build options to be used for building the program executable. The list of supported options is described in "Build Options" below.
        /// </param>
        /// <param name="pfn_notify"> 
        /// A function pointer to a notification routine. The notification routine is a callback function that an application can register and which will be called when the program executable has been built (successfully or unsuccessfully). If pfn_notify is not NULL, clBuildProgram does not need to wait for the build to complete and can return immediately. If pfn_notify is NULL, clBuildProgram does not return until the build has completed. This callback function may be called asynchronously by the OpenCL implementation. It is the application's responsibility to ensure that the callback function is thread-safe.
        /// </param>
        /// <param name="user_data"> 
        /// Passed as an argument when pfn_notify is called. user_data can be NULL.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode BuildProgram(this ComputeProgram program, Int32 num_devices, ComputeDevice* device_list, String options, ProgramNotifyDelegate pfn_notify, IntPtr user_data)
        {
            return CL.BuildProgram(program, num_devices, device_list, options, pfn_notify, user_data);
        }

        /// <summary>[requires: v1.0]
        /// Creates a kernal object.
        /// </summary>
        /// <param name="program"> 
        /// A program object with a successfully built executable.
        /// </param>
        /// <param name="kernel_name"> 
        /// A function name in the program declared with the Kernel qualifier
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static ComputeKernel CreateKernel(this ComputeProgram program, String kernel_name, [OutAttribute] out ErrorCode errcode_ret)
        {
            return CL.CreateKernel(program, kernel_name, out errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Creates a kernal object.
        /// </summary>
        /// <param name="program"> 
        /// A program object with a successfully built executable.
        /// </param>
        /// <param name="kernel_name"> 
        /// A function name in the program declared with the Kernel qualifier
        /// </param>
        /// <param name="errcode_ret"> 
        /// Returns an appropriate error code. If errcode_ret is NULL, no error code is returned.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ComputeKernel CreateKernel(this ComputeProgram program, String kernel_name, [OutAttribute] ErrorCode* errcode_ret)
        {
            return CL.CreateKernel(program, kernel_name, errcode_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetProgramBuildInfo(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] IntPtr[] param_value_size_ret)
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetProgramBuildInfo(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] out IntPtr param_value_size_ret)
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetProgramBuildInfo(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, IntPtr param_value, [OutAttribute] IntPtr* param_value_size_ret)
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetProgramBuildInfo<T4>(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetProgramBuildInfo<T4>(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetProgramBuildInfo<T4>(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetProgramBuildInfo<T4>(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[,] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetProgramBuildInfo<T4>(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetProgramBuildInfo<T4>(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetProgramBuildInfo<T4>(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[,,] param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetProgramBuildInfo<T4>(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[,,] param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetProgramBuildInfo<T4>(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] T4[,,] param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetProgramBuildInfo<T4>(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T4 param_value, [OutAttribute] IntPtr[] param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, ref param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static ErrorCode GetProgramBuildInfo<T4>(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T4 param_value, [OutAttribute] out IntPtr param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, ref param_value, out param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Returns build information for each device in the program object.
        /// </summary>
        /// <param name="program"> 
        /// Specifies the program object being queried.
        /// </param>
        /// <param name="device"> 
        /// Specifies the device for which build information is being queried. device must be a valid device associated with program.
        /// </param>
        /// <param name="param_name"> 
        /// Specifies the information to query. The list of supported param_name types and the information returned in param_value by clGetProgramBuildInfo is described in the table below. cl_program_buid_infoReturn Type and Info. returned in param_valueProgramBuildStatusReturn type: cl_build_status  Returns the build status of program for a specific device as given by device. This can be one of the following: CL_BUILD_NONE. The build status returned if no build has been performed on the specified program object for device. CL_BUILD_ERROR. The build status returned if the last call to clBuildProgram on the specified program object for device generated an error. CL_BUILD_SUCCESS. The build status retrned if the last call to clBuildProgram on the specified program object for device was successful. CL_BUILD_IN_PROGRESS. The build status returned if the last call to 	clBuildProgram on the specified program object for device has not finished. CL_PROGRAM_BUILD_OPTIONSReturn type: char[]  Return the build options specified by the options argument in 	clBuildProgram for device.  If build status of program for device is CL_BUILD_NONE, an empty string is returned. CL_PROGRAM_BUILD_LOGReturn type: char[]  Return the build log when clBuildProgram was called for device. If build status of program for device is CL_BUILD_NONE, an empty string is returned.
        /// </param>
        /// <param name="param_value_size"> 
        /// Specifies the size in bytes of memory pointed to by param_value. This size must be greater than or equal to the size of return type as described in the table above.
        /// </param>
        /// <param name="param_value"> 
        /// A pointer to memory where the appropriate result being queried is returned. If param_value is NULL, it is ignored.
        /// </param>
        /// <param name="param_value_size_ret"> 
        /// Returns the actual size in bytes of data copied to param_value. If param_value_size_ret is NULL, it is ignored.
        /// </param>
        [CLSCompliant(false)]
        public static unsafe ErrorCode GetProgramBuildInfo<T4>(this ComputeProgram program, ComputeDevice device, OpenTK.Compute.CL10.ProgramBuildInfo param_name, IntPtr param_value_size, [InAttribute, OutAttribute] ref T4 param_value, [OutAttribute] IntPtr* param_value_size_ret)
            where T4 : struct
        
        {
            return CL.GetProgramBuildInfo(program, device, param_name, param_value_size, ref param_value, param_value_size_ret);
        }

        /// <summary>[requires: v1.0]
        /// Decrements the program reference count.
        /// </summary>
        /// <param name="program"></param>
        public static ErrorCode ReleaseProgram(this ComputeProgram program)
        {
            return CL.ReleaseProgram(program);
        }

        /// <summary>[requires: v1.0]
        /// Increments the program reference count.
        /// </summary>
        /// <param name="program"></param>
        public static ErrorCode RetainProgram(this ComputeProgram program)
        {
            return CL.RetainProgram(program);
        }

    }

    /// <summary>
    /// Defines methods to simplify ComputeSampler usage.
    /// </summary>
    public partial struct ComputeSampler : IComparable<ComputeSampler>, IEquatable<ComputeSampler>
    {
        internal IntPtr Value;

        #region IComparable<ComputeSampler> Implementation

        /// <summary>
        /// Returns the sort order of the current instance compared to the specified <see cref="ComputeSampler"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputeSampler"/> to compare with the current <see cref="ComputeSampler"/>.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        public int CompareTo(ComputeSampler other)
        {
            int result = 0;
            if (result == 0)
                result = Value.CompareTo(other.Value);
            return result;
        }

        #endregion

        #region IEquatable<ComputeSampler> Implementation

        /// <summary>
        /// Determines whether the specified <see cref="ComputeSampler"/> is equal to the current <see cref="ComputeSampler"/>.
        /// </summary>
        /// <param name="other">The <see cref="ComputeSampler"/> to compare with the current <see cref="ComputeSampler"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputeSampler"/> is equal to the current
        /// <see cref="ComputeSampler"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(ComputeSampler other)
        {
            bool result = true;
            result &= Value.Equals(other.Value);
            return result;
        }

        #endregion

        #region Public Members

        /// <summary>Defines a zero (or null) <see cref="ComputeSampler"/></summary>
        public static readonly ComputeSampler Zero = new ComputeSampler();

        /// <summary>Tests two <see cref="ComputeSampler"/> instances for equality.</summary>
        public static bool operator ==(ComputeSampler left, ComputeSampler right)
        {
            return left.Equals(right);
        }

        /// <summary>Tests two <see cref="ComputeSampler"/> instances for inequality.</summary>
        public static bool operator !=(ComputeSampler left, ComputeSampler right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="ComputeSampler"/>.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with the current <see cref="ComputeSampler"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ComputeSampler"/> is equal to the current
        /// <see cref="ComputeSampler"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object other)
        {
            return other is ComputeSampler && Equals((ComputeSampler)other);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="ComputeSampler"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= Value.GetHashCode();
            return hash;
        }

        #endregion
    }

    /// <summary>
    /// Defines methods to simplify ComputeSampler usage.
    /// </summary>
    public static partial class ComputeSamplerExtensions
    {
    }

    /// <summary>
    /// Defines methods to simplify ContextProperty usage.
    /// </summary>
    public partial struct ContextProperty : IComparable<ContextProperty>, IEquatable<ContextProperty>
    {
        IntPtr Property;
        IntPtr Value;

        #region IComparable<ContextProperty> Implementation

        /// <summary>
        /// Returns the sort order of the current instance compared to the specified <see cref="ContextProperty"/>.
        /// </summary>
        /// <param name="other">The <see cref="ContextProperty"/> to compare with the current <see cref="ContextProperty"/>.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        public int CompareTo(ContextProperty other)
        {
            int result = 0;
            if (result == 0)
                result = Property.CompareTo(other.Property);
            if (result == 0)
                result = Value.CompareTo(other.Value);
            return result;
        }

        #endregion

        #region IEquatable<ContextProperty> Implementation

        /// <summary>
        /// Determines whether the specified <see cref="ContextProperty"/> is equal to the current <see cref="ContextProperty"/>.
        /// </summary>
        /// <param name="other">The <see cref="ContextProperty"/> to compare with the current <see cref="ContextProperty"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ContextProperty"/> is equal to the current
        /// <see cref="ContextProperty"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(ContextProperty other)
        {
            bool result = true;
            result &= Property.Equals(other.Property);
            result &= Value.Equals(other.Value);
            return result;
        }

        #endregion

        #region Public Members

        /// <summary>Defines a zero (or null) <see cref="ContextProperty"/></summary>
        public static readonly ContextProperty Zero = new ContextProperty();

        /// <summary>Tests two <see cref="ContextProperty"/> instances for equality.</summary>
        public static bool operator ==(ContextProperty left, ContextProperty right)
        {
            return left.Equals(right);
        }

        /// <summary>Tests two <see cref="ContextProperty"/> instances for inequality.</summary>
        public static bool operator !=(ContextProperty left, ContextProperty right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="ContextProperty"/>.
        /// </summary>
        /// <param name="other">The <see cref="System.Object"/> to compare with the current <see cref="ContextProperty"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="ContextProperty"/> is equal to the current
        /// <see cref="ContextProperty"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object other)
        {
            return other is ContextProperty && Equals((ContextProperty)other);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="ContextProperty"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= Property.GetHashCode();
            hash ^= Value.GetHashCode();
            return hash;
        }

        #endregion
    }

    /// <summary>
    /// Defines methods to simplify ContextProperty usage.
    /// </summary>
    public static partial class ContextPropertyExtensions
    {
    }
}
